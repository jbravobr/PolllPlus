using Newtonsoft.Json;
using Ninject;
using PollPlus.Domain;
using PollPlus.Domain.Enumeradores;
using PollPlus.Helpers;
using PollPlus.Models;
using PollPlus.Repositorio;
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
                var u = (await this.service.RetornarTodosUsuarios()).First(x => x.Email == email && x.Senha == senha);

                var user = new UsuarioMobile
                {
                    DataNascimento = u.DataNascimento,
                    Email = u.Email,
                    DDD = u.DDD.ToString(),
                    Municipio = u.Municipio,
                    Nome = u.Nome,
                    Sexo = u.Sexo,
                    Telefone = u.Telefone,
                    Id = u.Id
                };

                var lista = new List<CategoriaMobile>();
                foreach (var item in u.UsuarioCategoria)
                {
                    lista.Add(new CategoriaMobile { Id = item.Categoria.Id, Nome = item.Categoria.Nome });
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

                if ((await this.service.RetornarTodosUsuarios()).Any(x => x.Email == usuarioJson.Email))
                    return BadRequest("Email Já existe");

                var retornoInsertUsuario = await this.service.InserirRetornarUsuario(usuarioJson);

                if (retornoInsertUsuario != null)
                    EnviarEmailConfirmacaoCadastro(usuarioJson);

                var user = new UsuarioMobile
                {
                    DataNascimento = retornoInsertUsuario.DataNascimento,
                    DDD = retornoInsertUsuario.DDD.ToString(),
                    Municipio = retornoInsertUsuario.Municipio,
                    Nome = retornoInsertUsuario.Nome,
                    Sexo = retornoInsertUsuario.Sexo,
                    Telefone = retornoInsertUsuario.Telefone,
                    Id = retornoInsertUsuario.Id,
                    Email = retornoInsertUsuario.Email
                };

                //var lista = new List<CategoriaMobile>();
                //foreach (var item in retornoInsertUsuario.UsuarioCategoria)
                //{
                //    lista.Add(new CategoriaMobile { Id = item.Categoria.Id, Nome = item.Categoria.Nome });
                //}

                //user.Categorias = lista;

                var json = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(user.Id));

                return Ok(user.Id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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

                var retornoInsertUsuario = await this.service.AtualizarUsuario(usuarioJson);

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
                    var e = MapeiaEnqueteDomainParaEnqueteMobile(enquetes);
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
        [Route("enqueteinteresse/{id}/{empresaId}")]
        public async Task<IHttpActionResult> GetEnquetesInteresse(int id, int empresaId)
        {
            List<Enquete> enquetes = null;

            if (id > 0)
            {
                Expression<Func<Enquete, bool>> filtro = (x) => x.Id > id && x.Tipo == EnumTipoEnquete.Interesse
                && x.EmpresaId == empresaId && x.Status == EnumStatusEnquete.Publicada;
                enquetes = (await enqueteRepo.ProcurarPorColecao(filtro)).ToList();
            }
            else
            {
                Expression<Func<Enquete, bool>> filtro = (x) => x.Tipo == EnumTipoEnquete.Interesse
                && x.EmpresaId == empresaId && x.Status == EnumStatusEnquete.Publicada;
                enquetes = (await enqueteRepo.ProcurarPorColecao(filtro)).ToList();
            }

            try
            {
                if (enquetes != null)
                {

                    /*foreach (var enquete in enquetes.Where(w => w.PerguntaId != null))
                    {
                        Expression<Func<Resposta, bool>> filtro = (x) => x.PerguntaId == enquete.PerguntaId;
                        var respostas = (await this.respostaRepo.ProcurarPorColecao(filtro));
                        enquete.Pergunta.Resposta = respostas.ToList();
                    }*/


                    var e = MapeiaEnqueteDomainParaEnqueteMobile(enquetes).ToList();
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

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
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
                            if (EnviarEmailConfirmacaoVoucher(respondeJson.Usuario, item.Voucher.Identificador, item.Voucher.DataValidade))
                            {
                                item.Voucher.Status = EnumStatusVoucher.Indisponivel;
                                this.voucherRepo.Atualizar(item.Voucher);
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
        private bool EnviarEmailConfirmacaoVoucher(Usuario usuario, string voucherNro, DateTime dataValidade)
        {
            var _corpoMessage = new StringBuilder();

            _corpoMessage.Append(String.Format("<p>Está é a confirmação da criação do seu voucher número {0}.</p>", voucherNro));
            _corpoMessage.AppendLine(String.Format("<p>Este voucher é valido até {0}.</p>", dataValidade));
            _corpoMessage.AppendLine("Caso você não entenda do que este e-mail trata-se, favor desconsiderar o mesmo.");

            var _message = Util.MontaMailMessage(usuario.Email, _corpoMessage.ToString(), "Cadastro de usuário - Sistema Mais");

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
        [Route("banners/{id}/{empresaId}")]
        public async Task<IHttpActionResult> GetBanners(int id, int empresaId)
        {
            ICollection<Banner> banners;

            if (id <= 0)
                banners = (await this.bannerRepo.RetornarTodosBanners()).Where(b => b.EmpresaBanner.Any(e => e.EmpresaId == empresaId)).ToList();
            else
                banners = (await this.bannerRepo.RetornarTodosBanners()).Where(b => b.Id > id && b.EmpresaBanner.Any(e => e.EmpresaId == empresaId)).ToList();

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

        private IEnumerable<EnqueteMobile> MapeiaEnqueteDomainParaEnqueteMobile(ICollection<Enquete> enquetes)
        {
            foreach (var enquete in enquetes)
            {
                yield return new EnqueteMobile
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
                    Categoria = GetCategoriaById(enquete.EnqueteCategoria.First().CategoriaId).Result
                };
            }
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
                    Descricao = enquete.Descricao
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
        public DateTime DataNascimento { get; set; }
        public EnumSexo Sexo { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public string Municipio { get; set; }
        public List<CategoriaMobile> Categorias { get; set; }
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
