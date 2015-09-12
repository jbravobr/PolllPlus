using Newtonsoft.Json;
using Ninject;
using PollPlus.Domain;
using PollPlus.Domain.Enumeradores;
using PollPlus.Helpers;
using PollPlus.Models;
using PollPlus.Repositorio;
using PollPlus.Service;
using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PollPlus.Controllers
{
    [RoutePrefix("maisapi/usuario")]
    public class AccountAPIController : ApiController
    {
        private UsuarioRepositorio service = new UsuarioRepositorio();

        private EnqueteRepositorio enqueteRepo = new EnqueteRepositorio();

        private RespostaRepositorio respostaRepo = new RespostaRepositorio();

        private PerguntaRespostaRepositorio perguntaRespostaRepo = new PerguntaRespostaRepositorio();

        private CategoriaRepositorio catRepo = new CategoriaRepositorio();

        private BannerRepositorio bannerRepo = new BannerRepositorio();

        private GeolocalizacaoRepositorio geoRepo = new GeolocalizacaoRepositorio();

        private VoucherRepositorio voucherRepo = new VoucherRepositorio();

        private EnqueteVoucherRepositorio enqueteVoucherRepo = new EnqueteVoucherRepositorio();

        private AmigoEnqueteRepositorio amigoRepo = new AmigoEnqueteRepositorio();

        private UsuarioCategoriaRepositorio ucRepo = new UsuarioCategoriaRepositorio();

        public AccountAPIController() { }

        [HttpPost]
        [Route("geolocalizacao")]
        public async Task<IHttpActionResult> PostGeo([FromBody]string geo)
        {
            if (String.IsNullOrEmpty(geo))
                return BadRequest();

            var geoJson = JsonConvert.DeserializeObject<Geolocalizacao>(geo);
            var gravou = await this.geoRepo.InserirGeolocalizacao(geoJson);

            if (gravou)
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("recuperardados/{usuarioId}")]
        public async Task<IHttpActionResult> RecuperarDados(int usuarioId)
        {
            if (usuarioId <= 0)
                return BadRequest("Id inválido");

            var respostas = await this.perguntaRespostaRepo.RetornarTodos();
            var usuarioRespostas = respostas.Where(c => c.UsuarioId == usuarioId);

            var json = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(usuarioRespostas));

            return Ok(json);
        }

        [HttpPost]
        [Route("errou")]
        public async Task<IHttpActionResult> EsqueciMinhaSenha([FromBody]string email)
        {
            try
            {
                var _email = JsonConvert.DeserializeObject<string>(email);
                var _usuario = (await this.service.RetornarTodosUsuarios()).FirstOrDefault(u => u.Email == _email);

                if (_usuario != null)
                {
                    EnviarEmailEsqueciMinhaSenha(_usuario, _usuario.Senha);
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("autenticar/{email}/{senha}")]
        public async Task<IHttpActionResult> Autenticar(string email, string senha)
        {

            if ((await this.service.RetornarTodosUsuarios()).Any(x => x.Email == email && x.Senha == senha))
            {
                var u = (await this.service.RetornarTodosUsuarios()).Where(x => x.Email == email && x.Senha == senha).First();

                var user = new UsuarioMobile
                {
                    DataNascimento = u.DataNascimento,
                    Email = u.Email,
                    Senha = u.Senha,
                    DDD = u.DDD.ToString(),
                    Municipio = u.Municipio,
                    FacebookID = u.FacebookID,
                    Nome = u.Nome,
                    Sexo = u.Sexo,
                    Telefone = u.Telefone,
                    Id = u.Id
                };

                var lista = new List<CategoriaMobile>();
                foreach (var item in u.UsuarioCategoria)
                {
                    lista.Add(new CategoriaMobile { Id = item.Categoria.Id, Nome = item.Categoria.Nome, UsuarioId = user.Id });
                }

                user.Categorias = lista;

                return Ok(user);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("novocadastro")]
        public async Task<IHttpActionResult> NovoCadastro([FromBody]string usuario)
        {
            if (String.IsNullOrEmpty(usuario))
                return InternalServerError(new ArgumentException("Json inválido"));

            try
            {
                var usuarioJson = JsonConvert.DeserializeObject<Usuario>(usuario);

                //if (!String.IsNullOrEmpty(usuarioJson.Email) && (await this.service.RetornarTodosUsuarios()).Any(x => x.Email == usuarioJson.Email))
                //    return BadRequest("Email Já existe");

                if (usuarioJson.DataNascimento == null && usuarioJson.Sexo == null)
                {
                    usuarioJson.DataNascimento = null;
                    usuarioJson.Sexo = null;
                }

                var retornoInsertUsuario = await this.service.InserirRetornarUsuario(usuarioJson);
                var listaCategorias = new List<Categoria>();

                if (!String.IsNullOrEmpty(usuarioJson.CategoriaMobileSelection))
                {
                    List<int> catIds = new List<int>();
                    foreach (var item in usuarioJson.CategoriaMobileSelection.Split(';'))
                    {
                        var uc = new UsuarioCategoria { UsuarioId = retornoInsertUsuario.Id, CategoriaId = Convert.ToInt32(item) };
                        await this.ucRepo.InserirUsuarioCategoria(uc);
                        catIds.Add(Convert.ToInt32(item));
                    }

                    listaCategorias = (await this.catRepo.RetornarTodasCategorias()).Where(x => catIds.Contains(x.Id)).ToList();
                }

                if (retornoInsertUsuario != null && !String.IsNullOrEmpty(retornoInsertUsuario.Email))
                    EnviarEmailConfirmacaoCadastro(usuarioJson);

                UsuarioMobile user;

                if (listaCategorias != null && listaCategorias.Any())
                {
                    user = new UsuarioMobile
                    {
                        DataNascimento = retornoInsertUsuario.DataNascimento,
                        DDD = retornoInsertUsuario.DDD.ToString(),
                        Municipio = retornoInsertUsuario.Municipio,
                        Nome = retornoInsertUsuario.Nome,
                        Sexo = retornoInsertUsuario.Sexo,
                        Telefone = retornoInsertUsuario.Telefone,
                        Id = retornoInsertUsuario.Id,
                        Email = retornoInsertUsuario.Email,
                        Categorias = MapeiaCategoriaParaMobile(listaCategorias).ToList()
                    };
                }
                else
                {
                    user = new UsuarioMobile
                    {
                        DataNascimento = retornoInsertUsuario.DataNascimento,
                        DDD = retornoInsertUsuario.DDD.ToString(),
                        Municipio = retornoInsertUsuario.Municipio,
                        Nome = retornoInsertUsuario.Nome,
                        Sexo = retornoInsertUsuario.Sexo,
                        Telefone = retornoInsertUsuario.Telefone,
                        Id = retornoInsertUsuario.Id,
                        Email = retornoInsertUsuario.Email,
                    };
                }

                var json = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(user.Id));

                if (usuarioJson.DataNascimento != null)
                    return Ok(user.Id);
                else
                    return Ok(retornoInsertUsuario);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("atualizacategoriasFB")]
        public async Task<IHttpActionResult> AtualizaCategoriasViaFB([FromBody]string usuarioJson)
        {
            try
            {
                var _usuario = JsonConvert.DeserializeObject<Usuario>(usuarioJson);
                var _usuarioBD = await this.service.RetornarUsuarioPorId(_usuario.Id);

                List<int> catIds = new List<int>();

                if (!String.IsNullOrEmpty(_usuario.CategoriaMobileSelection))
                    await this.ucRepo.DeletarCategoriasDoUsuario(_usuarioBD.Id);

                foreach (var item in _usuario.CategoriaMobileSelection.Split(';'))
                {
                    var uc = new UsuarioCategoria { UsuarioId = _usuarioBD.Id, CategoriaId = Convert.ToInt32(item) };
                    await this.ucRepo.InserirUsuarioCategoria(uc);
                    catIds.Add(Convert.ToInt32(item));
                }

                _usuarioBD.Email = _usuario.Email;
                _usuarioBD.CategoriaMobileSelection = _usuario.CategoriaMobileSelection;

                await this.service.AtualizarUsuario(_usuarioBD);

                var listaCategorias = (await this.catRepo.RetornarTodasCategorias()).Where(x => catIds.Contains(x.Id)).ToList();

                var user = new UsuarioMobile
                {
                    DataNascimento = _usuarioBD.DataNascimento,
                    DDD = _usuarioBD.DDD.ToString(),
                    Municipio = _usuarioBD.Municipio,
                    Nome = _usuarioBD.Nome,
                    Sexo = _usuarioBD.Sexo,
                    Telefone = _usuarioBD.Telefone,
                    Id = _usuarioBD.Id,
                    Email = _usuarioBD.Email,
                    Categorias = MapeiaCategoriaParaMobile(listaCategorias).ToList()
                };

                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("atualizapush/{pushWooshToken}/{usuarioId}")]
        public async Task<IHttpActionResult> AtualizaDadosPush(string pushWooshToken, int usuarioId)
        {
            if (!String.IsNullOrEmpty(pushWooshToken))
            {
                var usuario = await this.service.RetornarUsuarioPorId(usuarioId);
                usuario.PushWooshToken = pushWooshToken;

                var result = await this.service.AtualizarUsuario(usuario);

                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("atualizafacebook/{facebookID}/{usuarioId}")]
        public async Task<IHttpActionResult> AtualizaUsuarioFacebookId(string facebookID, int usuarioId)
        {
            if (!String.IsNullOrEmpty(facebookID))
            {
                var usuario = await this.service.RetornarUsuarioPorId(usuarioId);
                usuario.FacebookID = facebookID;

                var result = await this.service.AtualizarUsuario(usuario);

                return Ok(result);
            }

            return BadRequest();
        }

        private IEnumerable<CategoriaMobile> MapeiaCategoriaParaMobile(List<Categoria> cat)
        {
            foreach (var c in cat)
            {
                yield return new CategoriaMobile { Id = c.Id, Nome = c.Nome };
            }
        }

        [HttpPost]
        [Route("atualizarcadastro")]
        public async Task<IHttpActionResult> AtualizarCadastro([FromBody]string usuario)
        {
            if (String.IsNullOrEmpty(usuario))
                return BadRequest("Usuário inválido");

            try
            {
                var usuarioJson = JsonConvert.DeserializeObject<Usuario>(usuario);

                var usuarioBD = await this.service.RetornarUsuarioPorId(usuarioJson.Id);

                if (usuarioBD != null)
                {
                    usuarioBD.CategoriaMobileSelection = usuarioJson.CategoriaMobileSelection.TrimEnd(';');
                    usuarioBD.DataAtualizacao = DateTime.Now;
                    usuarioBD.DataNascimento = usuarioJson.DataNascimento;
                    usuarioBD.DDD = usuarioJson.DDD;
                    usuarioBD.Email = usuarioJson.Email;
                    usuarioBD.EmpresaApp = usuarioJson.EmpresaApp;
                    usuarioBD.FacebookID = usuarioJson.FacebookID;
                    usuarioBD.Municipio = usuarioJson.Municipio;
                    usuarioBD.Nome = usuarioJson.Nome;
                    usuarioBD.PushWooshToken = usuarioJson.PushWooshToken;
                    usuarioBD.Sexo = usuarioJson.Sexo;
                    usuarioBD.Telefone = usuarioJson.Telefone;
                }

                var retornoInsertUsuario = await this.service.AtualizarUsuario(usuarioBD);

                if (retornoInsertUsuario)
                {
                    await this.ucRepo.DeletarCategoriasDoUsuario(usuarioJson.Id);

                    List<int> catIds = new List<int>();
                    foreach (var item in usuarioJson.CategoriaMobileSelection.TrimEnd(';').Split(';'))
                    {
                        var uc = new UsuarioCategoria { UsuarioId = usuarioJson.Id, CategoriaId = Convert.ToInt32(item) };
                        await this.ucRepo.InserirUsuarioCategoria(uc);
                        catIds.Add(Convert.ToInt32(item));
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("enquetepublica/{id}")]
        public async Task<IHttpActionResult> GetEnquetesPublicas(int id)
        {
            List<Enquete> enquetes = null;

            if (id > 0)
                enquetes = (await enqueteRepo.RetornarTodos()).Where(e => e.Id > id && e.Tipo == Domain.Enumeradores.EnumTipoEnquete.Publica
                && e.Status == Domain.Enumeradores.EnumStatusEnquete.Publicada).ToList();
            else
                enquetes = (await enqueteRepo.RetornarTodos()).Where(e => e.Tipo == Domain.Enumeradores.EnumTipoEnquete.Publica
                && e.Status == Domain.Enumeradores.EnumStatusEnquete.Publicada).ToList();

            try
            {
                if (enquetes != null)
                {
                    var e = MapeiaEnqueteDomainParaEnqueteMobile(enquetes, true);
                    var enquetesJson = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(e));
                    return Ok(enquetesJson);
                }
                else
                    return Ok("Não há enquetes disponíveis");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("enqueteinteresse/{id}/{usuarioId}")]
        public async Task<IHttpActionResult> GetEnquetesInteresse(int id, int usuarioId)
        {
            List<Enquete> enquetes = null;
            List<Enquete> enquetesAmigos = new List<Enquete>();

            try
            {
                //if (id > 0)
                //{
                //    Expression<Func<Enquete, bool>> filtro = (x) => x.Id > id && x.Tipo == EnumTipoEnquete.Interesse
                //    && x.Status == EnumStatusEnquete.Publicada;
                //    enquetes = (await enqueteRepo.ProcurarPorColecao(filtro)).ToList();

                //    if (enquetes.Any(x => x.AmigoEnquete.Any()))
                //    {
                //        foreach (var enquete in enquetes)
                //        {
                //            if (enquete.AmigoEnquete.FirstOrDefault(x => x.UsuarioId == usuarioId) != null)
                //                enquetesAmigos.Add(enquete);
                //        }
                //    }

                //}
                //else
                //{
                Expression<Func<Enquete, bool>> filtro = (x) => x.Tipo == EnumTipoEnquete.Interesse
            && x.Status == EnumStatusEnquete.Publicada;
                enquetes = (await enqueteRepo.ProcurarPorColecao(filtro)).ToList();

                if (enquetes.Any(x => x.AmigoEnquete.Any()))
                {
                    foreach (var enquete in enquetes)
                    {
                        if (enquete.AmigoEnquete.FirstOrDefault(x => x.UsuarioId == usuarioId) != null)
                            enquetesAmigos.Add(enquete);
                    }
                    //}
                }
                //if (enquetesAmigos != null && enquetesAmigos.Any())
                if (enquetesAmigos != null)
                {

                    /*foreach (var enquete in enquetes.Where(w => w.PerguntaId != null))
                    {
                        Expression<Func<Resposta, bool>> filtro = (x) => x.PerguntaId == enquete.PerguntaId;
                        var respostas = (await this.respostaRepo.ProcurarPorColecao(filtro));
                        enquete.Pergunta.Resposta = respostas.ToList();
                    }*/


                    foreach (var _enquete in enquetes)
                    {
                        var achou = enquetesAmigos.FirstOrDefault(x => x.Id == _enquete.Id);
                        if (achou == null)
                            enquetes.FirstOrDefault(x => x.Id == _enquete.Id).AtivaNoFront = false;
                        else
                            enquetes.FirstOrDefault(x => x.Id == _enquete.Id).AtivaNoFront = true;
                    }


                    //var e = MapeiaEnqueteDomainParaEnqueteMobile(enquetesAmigos).ToList();
                    var e = MapeiaEnqueteDomainParaEnqueteMobile(enquetes, false).ToList();
                    //var _e = MapeiaMensagemParaMensagemMobile(enquetes.Where(x => x.PerguntaId == null).ToList()).ToList(); ;
                    //var todas = e.Union(_e);
                    var enquetesJson = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(e));
                    return Ok(enquetesJson);
                }
                else
                    return Ok("Não há enquetes disponíveis");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("retornaamigosencontrados")]
        public async Task<IHttpActionResult> GetAmigos([FromBody]string telefones)
        {
            var _tels = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<string>>(telefones));

            var _usuarios = await this.service.RetornarTodosUsuarios();

            var amigos = new List<Usuario>();
            foreach (var usuario in _usuarios.Distinct())
            {
                if (_tels.Contains(usuario.FacebookID))
                    amigos.Add(usuario);
            }

            var _result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(amigos));

            return Ok(_result);
        }

        [HttpGet]
        [Route("mensagem/{id}/{empresaId}")]
        public async Task<IHttpActionResult> GetMensagen(int id, int empresaId)
        {
            List<Enquete> enquetes = null;

            if (id > 0)
                enquetes = (await enqueteRepo.RetornarTodos()).Where(e => e.Id > id && e.Tipo == Domain.Enumeradores.EnumTipoEnquete.Mensagem
                && e.EmpresaId == empresaId && e.Status == Domain.Enumeradores.EnumStatusEnquete.Publicada).ToList();
            else
                enquetes = (await enqueteRepo.RetornarTodos()).Where(e => e.Tipo == Domain.Enumeradores.EnumTipoEnquete.Mensagem
                && e.EmpresaId == empresaId && e.Status == Domain.Enumeradores.EnumStatusEnquete.Publicada).ToList();

            try
            {
                if (enquetes != null && enquetes.Any())
                {
                    var enquetesJson = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(MapeiaMensagemParaMensagemMobile(enquetes)));
                    return Ok(enquetesJson);
                }
                else
                    return Ok("Não há mensagens");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("novaenquete")]
        public async Task<IHttpActionResult> NovaEnquete([FromBody]string enquete)
        {
            if (String.IsNullOrEmpty(enquete))
                return BadRequest("Enquete inválida");

            try
            {
                var enqueteJson = JsonConvert.DeserializeObject<Enquete>(enquete);
                var retornoInsertEnquete = await this.enqueteRepo.InserirRetornarEnquete(enqueteJson);

                var result = new RetornoGravacaoEnquete { EnqueteId = retornoInsertEnquete.Id, PerguntaId = (int)retornoInsertEnquete.PerguntaId };
                var listaEnvio = new List<string>();

                if (enqueteJson.colegas != null && !String.IsNullOrEmpty(enqueteJson.colegas))
                {
                    foreach (var amigo in enqueteJson.colegas.Split(';'))
                    {
                        await this.amigoRepo.InserirAmigoEnquete(new AmigoEnquete { UsuarioId = Convert.ToInt32(amigo), EnqueteId = retornoInsertEnquete.Id });

                        var _usuario = await this.service.RetornarUsuarioPorId(Convert.ToInt32(amigo));
                        var _usuarioCriador = await this.service.RetornarUsuarioPorId(enqueteJson.UsuarioId);

                        if (_usuario != null && !String.IsNullOrEmpty(_usuario.PushWooshToken) && _usuarioCriador != null)
                        {
                            listaEnvio.Add(_usuario.PushWooshToken);
                            this.EnvioPushWooshResult(listaEnvio, String.Format("{0} convidou você para responder uma Enquete!", _usuarioCriador.Nome));
                            listaEnvio.Clear();
                        }
                    }
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [NonAction]
        private bool EnvioPushWooshResult(List<string> p_mensagens, string texto)
        {
            var _retornoPushWoosh = new EnvioPush().EnviarPushNotification(p_mensagens, texto);

            return _retornoPushWoosh;
        }

        [HttpPost]
        [Route("gravaenqueterespostas")]
        public async Task<IHttpActionResult> SalvaRespostas([FromBody]string resposta)
        {
            if (String.IsNullOrEmpty(resposta))
                return BadRequest("Respostas inválidas - dados vazios");

            try
            {
                var respostasJson = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ICollection<RespostaMobile>>(resposta));
                var respostasDomain = MapeiaRespostaMobileParaRespostaDomain(respostasJson);

                var lista = new List<RespostaMobile>();
                foreach (var r in respostasDomain)
                {
                    var _resposta = await this.respostaRepo.InserirRetornarResposta(r);
                    lista.Add(new RespostaMobile { PerguntaServerId = r.PerguntaId, RespostaServerId = r.Id, TextoResposta = r.TextoResposta });
                }
                var json = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(lista));

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("respondeenquete")]
        public async Task<IHttpActionResult> RespondeEnquete([FromBody]string perguntaresposta)
        {
            try
            {
                if (String.IsNullOrEmpty(perguntaresposta))
                    return BadRequest("Objeto vazio");

                var respondeJson = JsonConvert.DeserializeObject<PerguntaResposta>(perguntaresposta);
                var respondeu = await this.perguntaRespostaRepo.InserirPerguntaResposta(respondeJson);

                var pr = await this.perguntaRespostaRepo.RetornarPerguntaRespostaPorPergunta(respondeJson.PerguntaId);
                var totalRespostas = pr.Count;

                var calculos = pr
                 .GroupBy(n => n.RespostaId)
                 .Select(n => new
                 {
                     Resposta = n.Key,
                     Quantidade = n.Count(),
                     Percentual = n.Count() * 100 / totalRespostas
                 }
                 )
                 .ToList();

                foreach (var c in calculos)
                {
                    var pergResp = await this.perguntaRespostaRepo.RetornarPerguntaRespostaPorResposta(c.Resposta);

                    foreach (var p in pergResp)
                    {
                        p.percentual = Convert.ToDouble(c.Percentual);
                        await this.perguntaRespostaRepo.AtualizarPerguntaResposta(p);
                    }
                }

                var enquete = (await this.enqueteRepo.RetornarTodasEnquetes()).First(e => e.PerguntaId == respondeJson.PerguntaId);

                if (enquete.TemVoucher)
                {
                    var vouchers = await this.enqueteVoucherRepo.RetornarEnqueteVoucherPorEnquete(enquete.Id);

                    foreach (var item in vouchers)
                    {
                        if (item.Voucher.Status == EnumStatusVoucher.Disponivel && !item.Voucher.Usado)
                        {
                            var u = await this.service.RetornarUsuarioPorId(respondeJson.UsuarioId);

                            if (EnviarEmailConfirmacaoVoucher(u, item.Voucher.Identificador, item.Voucher.DataValidade, item.Voucher.Descricao))
                            {
                                var v = await this.voucherRepo.RetornarVoucherPorId(item.Id);
                                v.Status = EnumStatusVoucher.Indisponivel;
                                await this.voucherRepo.AtualizarVoucher(v);
                                break;
                            }
                        }

                    }
                }

                var perguntasRespostas = await this.perguntaRespostaRepo.RetornarPerguntaRespostaPorPergunta(respondeJson.PerguntaId);
                var _toList = perguntasRespostas.ToList();
                var obj = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(MapeiaParaPerguntaRespostaMobile(_toList)));

                return Ok(obj);
            }
            catch (Exception ex)
            {
                //File.WriteAllText(@"E:\Inetroot\app01.training.cloudfacil.net\Images\erroRespondeEnquete.txt", ex.Message);
                return InternalServerError(ex);
            }
        }

        [NonAction]
        private bool EnviarEmailConfirmacaoCadastro(Usuario usuario)
        {
            var _corpoMessage = new StringBuilder();

            _corpoMessage.Append("<p>Está é a confirmação da criação do seu usuário para acesso ao Sistema de Mais.</p>");
            _corpoMessage.AppendLine(String.Format("<p>Seu login é: {0}.</p>", usuario.Email));
            _corpoMessage.AppendLine("Caso você não entenda do que este e-mail trata-se, favor desconsiderar o mesmo.");

            var _message = Util.MontaMailMessage(usuario.Email, _corpoMessage.ToString(), "Cadastro de usuário - Sistema Mais");

            return Util.SendMail(_message);
        }

        [NonAction]
        private bool EnviarEmailEsqueciMinhaSenha(Usuario usuario, string senha)
        {
            var _corpoMessage = new StringBuilder();

            _corpoMessage.Append("<p>Recuperação da Senha para acesso ao sistema Mais.</p>");
            _corpoMessage.AppendLine(String.Format("<p>Sua senha é: {0}.</p>", senha));
            _corpoMessage.AppendLine("Caso você não entenda do que este e-mail trata-se, favor desconsiderar o mesmo.");

            var _message = Util.MontaMailMessage(usuario.Email, _corpoMessage.ToString(), "Sistema Mais - Recuperação de senha");

            return Util.SendMail(_message);
        }

        [NonAction]
        private bool EnviarEmailConfirmacaoVoucher(Usuario usuario, string voucherNro, DateTime dataValidade, string voucherDescricao)
        {
            var _corpoMessage = new StringBuilder();

            _corpoMessage.Append(String.Format("<p>Está é a confirmação da criação do seu voucher número {0}.</p>", voucherNro));
            _corpoMessage.AppendLine(String.Format("<p>Este voucher é valido até {0}.</p>", dataValidade.ToString()));
            _corpoMessage.AppendLine(String.Format("<p>{0}</p>", voucherDescricao));
            _corpoMessage.AppendLine("Caso você não entenda do que este e-mail trata-se, favor desconsiderar o mesmo.");

            var _message = Util.MontaMailMessage(usuario.Email, _corpoMessage.ToString(), "Aviso de Sistema - Sistema Mais");

            return Util.SendMail(_message);
        }

        [HttpGet]
        [Route("baixacategorais/{categoriaId}")]
        public async Task<IHttpActionResult> GetCategorais()
        {
            var categorias = await this.catRepo.RetornarTodasCategorias();

            try
            {
                var cats = JsonConvert.SerializeObject(categorias);

                return Ok(cats);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("banners/{id}/{empresaId}/{categorias}")]
        public async Task<IHttpActionResult> GetBanners(int id, int empresaId, string categorias)
        {
            ICollection<Banner> banners;
            List<int> cats = new List<int>();

            foreach (var item in categorias.Split(';'))
            {
                cats.Add(Convert.ToInt32(item));
            }

            if (id <= 0)
                banners = (await this.bannerRepo.RetornarTodosBanners())
                    .Where(b => b.EmpresaBanner.Any(e => e.EmpresaId == empresaId) && b.CategoriaBanner.All(x => cats.Contains(x.CategoriaId)))
                    .ToList();
            else
                banners = (await this.bannerRepo.RetornarTodosBanners())
                    .Where(b => b.EmpresaBanner.Any(e => e.EmpresaId == empresaId) && b.CategoriaBanner.All(x => cats.Contains(x.CategoriaId)))
                    .ToList();

            return Ok(JsonConvert.SerializeObject(banners));
        }

        private ICollection<Resposta> MapeiaRespostaMobileParaRespostaDomain(ICollection<RespostaMobile> respMobile)
        {
            return respMobile.Select(r => new Resposta { TextoResposta = r.TextoResposta, PerguntaId = r.PerguntaServerId }).ToList();
        }

        private IEnumerable<PerguntaRespostaMobile> MapeiaParaPerguntaRespostaMobile(ICollection<PerguntaResposta> p)
        {
            foreach (var item in p)
            {
                yield return new PerguntaRespostaMobile { percentual = item.percentual, PerguntaId = item.PerguntaId, RespostaId = item.RespostaId, TextoResposta = string.Empty, UsuarioId = item.UsuarioId };
            }
        }

        private List<EnqueteMobile> MapeiaEnqueteDomainParaEnqueteMobile(ICollection<Enquete> enquetes, bool publica)
        {
            var lista = new List<EnqueteMobile>();

            foreach (var enquete in enquetes)
            {
                var e = new EnqueteMobile
                {
                    Id = 0,
                    Pergunta = new PerguntaMobile
                    {
                        Id = 0,
                        PerguntaServerId = enquete.Pergunta.Id,
                        TextoPergunta = enquete.Pergunta.TextoPergunta,
                        Respostas = enquete.Pergunta.Resposta.Select(r => new RespostaMobile
                        {
                            Id = 0,
                            PerguntaServerId = r.PerguntaId,
                            TextoResposta = r.TextoResposta,
                            RespostaServerId = r.Id,
                            Imagem = r.RespostaImagem != null && r.RespostaImagem.Any() ? r.RespostaImagem.First(x => x.RespostaId == r.Id).Imagem : String.Empty
                        }).ToList()
                    },
                    PerguntaServerId = enquete.Pergunta.Id,
                    ServerEnqueteId = enquete.Id,
                    Status = enquete.Status,
                    Tipo = enquete.Tipo,
                    Titulo = enquete.Pergunta.TextoPergunta,
                    UrlVideo = enquete.UrlVideo,
                    UsuarioId = enquete.UsuarioId,
                    Imagem = enquete.Imagem,
                    TemVoucher = enquete.TemVoucher,
                    UsuarioCriador = enquete.Usuario.Nome,
                    AtivaNoFront = publica == true ? false : enquete.AtivaNoFront
                };

                if (enquete.EnqueteCategoria != null && enquete.EnqueteCategoria.Any())
                {
                    e.Categoria = enquete.EnqueteCategoria.First().Categoria;
                }

                lista.Add(e);
            }

            return lista;
        }

        private IEnumerable<EnqueteMobile> MapeiaMensagemParaMensagemMobile(ICollection<Enquete> enquetes)
        {
            foreach (var enquete in enquetes)
            {
                yield return new EnqueteMobile
                {
                    Id = 0,
                    ServerEnqueteId = enquete.Id,
                    Status = enquete.Status,
                    Tipo = enquete.Tipo,
                    Titulo = enquete.Titulo,
                    UrlVideo = enquete.UrlVideo,
                    UsuarioId = enquete.UsuarioId,
                    Imagem = enquete.Imagem,
                    Categoria = GetCategoriaById(enquete.EnqueteCategoria.First().CategoriaId).Result,
                    Descricao = enquete.Descricao,
                    AtivaNoFront = false
                };
            }
        }

        private async Task<Categoria> GetCategoriaById(int categoriaId)
        {
            return await this.catRepo.RetornarCategoriaPorId(categoriaId);
        }
    }

    public class UsuarioMobile
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Senha { get; set; }
        public EnumSexo? Sexo { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public string Municipio { get; set; }
        public List<CategoriaMobile> Categorias { get; set; }
        public string FacebookID { get; set; }
        public string PushWooshToken { get; set; }
    }

    public class RespostaMobile
    {
        public int Id { get; set; }
        public string TextoResposta { get; set; }
        public int PerguntaServerId { get; set; }
        public int RespostaServerId { get; set; }
        public string Imagem { get; set; }
    }

    public class EnqueteMobile
    {
        public int Id { get; set; }
        public int ServerEnqueteId { get; set; }
        public string Titulo { get; set; }
        public string UrlVideo { get; set; }
        public PerguntaMobile Pergunta { get; set; }
        public int PerguntaServerId { get; set; }
        public EnumTipoEnquete Tipo { get; set; }
        public EnumStatusEnquete Status { get; set; }
        public int UsuarioId { get; set; }
        public string Imagem { get; set; }
        public Categoria Categoria { get; set; }
        public string Descricao { get; set; }
        public bool TemVoucher { get; set; }
        public string UsuarioCriador { get; set; }
        public bool? AtivaNoFront { get; set; }
    }

    public class PerguntaMobile
    {
        public int Id { get; set; }
        public string TextoPergunta { get; set; }
        public int PerguntaServerId { get; set; }
        public List<RespostaMobile> Respostas { get; set; }
    }

    public class CategoriaMobile
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
    }

    public class RetornoGravacaoEnquete
    {
        public int EnqueteId { get; set; }
        public int PerguntaId { get; set; }
    }

    public class PerguntaRespostaMobile
    {
        public int PerguntaId { get; set; }

        public int RespostaId { get; set; }

        public string TextoResposta { get; set; }

        public int UsuarioId { get; set; }

        public double percentual { get; set; }
    }
}
