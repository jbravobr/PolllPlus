using Newtonsoft.Json;
using Ninject;
using PollPlus.Domain;
using PollPlus.Helpers;
using PollPlus.Models;
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

        private RespostaRepositorio respostaRepo = new RespostaRepositorio();

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
                usuarioJson.Senha = Util.EncriptarSenha(usuarioJson.Senha);

                var retornoInsertUsuario = await this.service.InserirUsuario(usuarioJson);

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
                    var enquetesJson = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(enquetes));
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
                    var enquetesJson = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(enquetes));
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
                var respostasJson = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ICollection<Resposta>>(resposta));

                foreach (var r in respostasJson)
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
    }
}
