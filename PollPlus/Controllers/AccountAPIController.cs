using Newtonsoft.Json;
using Ninject;
using PollPlus.Domain;
using PollPlus.Helpers;
using PollPlus.Repositorio;
using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PollPlus.Controllers
{
    [RoutePrefix("maisapi/usuario")]
    public class AccountAPIController : ApiController
    {
        private UsuarioRepositorio service = new UsuarioRepositorio();

        private EnqueteRepositorio enqueteRepo = new EnqueteRepositorio();

        public AccountAPIController() { }

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
                var retornoInsertUsuario = await this.service.InserirUsuario(usuarioJson);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("enquete/{id}")]
        public async Task<IHttpActionResult> GetEnquetesPublicas(int id)
        {
            List<Enquete> enquetes = null;

            if (id > 0)
                enquetes = (await enqueteRepo.RetornarTodos()).Where(e => e.Id > id && e.Tipo == Domain.Enumeradores.EnumTipoEnquete.Publica).ToList();
            else
                enquetes = (await enqueteRepo.RetornarTodos()).Where(e => e.Tipo == Domain.Enumeradores.EnumTipoEnquete.Publica).ToList();

            if (enquetes != null)
            {
                var enquetesJson = JsonConvert.SerializeObject(enquetes);
                return Ok(enquetesJson);
            }
            else
                return BadRequest("Não há enquetes disponíveis");
        }

        [HttpGet]
        [Route("enquete/{id}")]
        public async Task<IHttpActionResult> GetEnquetesInteresse(int id)
        {
            List<Enquete> enquetes = null;

            if (id > 0)
                enquetes = (await enqueteRepo.RetornarTodos()).Where(e => e.Id > id && e.Tipo == Domain.Enumeradores.EnumTipoEnquete.Interesse).ToList();
            else
                enquetes = (await enqueteRepo.RetornarTodos()).Where(e => e.Tipo == Domain.Enumeradores.EnumTipoEnquete.Interesse).ToList();

            if (enquetes != null)
            {
                var enquetesJson = JsonConvert.SerializeObject(enquetes);
                return Ok(enquetesJson);
            }
            else
                return BadRequest("Não há enquetes disponíveis");
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
                var retornoInsertEnquete = await this.enqueteRepo.InserirEnquete(enqueteJson);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> SalvaRespostas(PerguntaViewModel Pergunta, List<string> resposta)
        {
            if (!ModelState.IsValid || !resposta.Any())
                return View(Pergunta);

            var respostas = MapeiaListaDeRespostas(resposta, Pergunta.Id);

            foreach (var r in respostas)
            {
                await this.serviceResposta.InserirResposta(r);
            }

            Pergunta.Resposta = AutoMapper.Mapper.Map<ICollection<RespostaViewModel>>(respostas.ToList());

            if (await this.servicePergunta.AtualizarPergunta(AutoMapper.Mapper.Map<Pergunta>(Pergunta)))
                return RedirectToAction("ListarEnquetes");
            else
                return View("NovaEnquete");
        }
    }
}
