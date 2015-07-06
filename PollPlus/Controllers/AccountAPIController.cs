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
using System.Linq;
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
        [Route("autenticar/{email}/{senha}")]
        public async Task<IHttpActionResult> Autenticar(string email, string senha)
        {
            try
            {
                var _usuario = (await this.service.RetornarTodosUsuarios()).FirstOrDefault(u => u.Email == email);

                var senhaDecrypt = Util.DescriptarSenha(_usuario.Senha);

                if (_usuario == null)
                    return Unauthorized();
                else if (_usuario != null && senha == senhaDecrypt)
                    return Ok();
                else
                    return Unauthorized();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("novocadastro")]
        public async Task<IHttpActionResult> NovoCadastro([FromBody]string usuario)
        {
            if (String.IsNullOrEmpty(usuario))
                return BadRequest("Usuário inválido");

            try
            {
                var usuarioJson = JsonConvert.DeserializeObject<Usuario>(usuario);
                usuarioJson.Senha = Util.EncriptarSenha(usuarioJson.Senha);

                var retornoInsertUsuario = await this.service.InserirUsuario(usuarioJson);

                if (retornoInsertUsuario)
                    EnviarEmailConfirmacaoCadastro(usuarioJson);

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
                    return BadRequest("Não há enquetes disponíveis");
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
                enquetes = (await enqueteRepo.RetornarTodos()).Where(e => e.Id > id && e.Tipo == Domain.Enumeradores.EnumTipoEnquete.Interesse
                && e.EmpresaId == empresaId && e.Status == Domain.Enumeradores.EnumStatusEnquete.Publicada).ToList();
            else
                enquetes = (await enqueteRepo.RetornarTodos()).Where(e => e.Tipo == Domain.Enumeradores.EnumTipoEnquete.Interesse
                && e.EmpresaId == empresaId && e.Status == Domain.Enumeradores.EnumStatusEnquete.Publicada).ToList();

            try
            {
                if (enquetes != null)
                {

                    foreach (var enquete in enquetes)
                    {
                        var respostas = (await this.respostaRepo.RetornarTodasRespostas()).Where(r => r.PerguntaId == enquete.Pergunta.Id);
                        enquete.Pergunta.Resposta = respostas.ToList();
                    }

                    var enquetesJson = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(MapeiaEnqueteDomainParaEnqueteMobile(enquetes)));
                    return Ok(enquetesJson);
                }
                else
                    return BadRequest("Não há enquetes disponíveis");
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

                return Ok(retornoInsertEnquete.PerguntaId);
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

                foreach (var r in respostasDomain)
                {
                    await this.respostaRepo.InserirResposta(r);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("respondeenquete")]
        public async Task<IHttpActionResult> RespondeEnquete([FromBody]string responde)
        {
            if (String.IsNullOrEmpty(responde))
                return BadRequest("Objeto vazio");

            var respondeJson = JsonConvert.DeserializeObject<PerguntaResposta>(responde);
            var respondeu = await Task.Factory.StartNew(() => this.perguntaRespostaRepo.InserirPerguntaResposta(respondeJson));

            var pr = await this.perguntaRespostaRepo.RetornarPerguntaRespostaPorPergunta(respondeJson.PerguntaId);
            var totalRespostas = pr.Count;

            var calculos = pr
             .GroupBy(n => n.Resposta)
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
                var pergResp = await this.perguntaRespostaRepo.RetornarPerguntaRespostaPorResposta(c.Resposta.Id);

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

            return Ok(respondeu);
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

            return Ok(JsonConvert.SerializeObject(categorias));
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
                            TextoResposta = r.TextoResposta
                        }).ToList()
                    },
                    PerguntaServerId = enquete.Pergunta.Id,
                    ServerEnqueteId = enquete.Id,
                    Status = enquete.Status,
                    Tipo = enquete.Tipo,
                    Titulo = enquete.Pergunta.TextoPergunta,
                    UrlVideo = enquete.UrlVideo,
                    UsuarioId = enquete.UsuarioId,
                    Imagem = enquete.Imagem
                };
            }
        }
    }

    public class RespostaMobile
    {
        public int Id { get; set; }
        public string TextoResposta { get; set; }
        public int PerguntaServerId { get; set; }
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
    }

    public class PerguntaMobile
    {
        public int Id { get; set; }
        public string TextoPergunta { get; set; }
        public int PerguntaServerId { get; set; }
        public List<RespostaMobile> Respostas { get; set; }
    }
}
