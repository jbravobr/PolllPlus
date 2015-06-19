using PagedList;
using PollPlus.Domain;
using PollPlus.Filter;
using PollPlus.Models;
using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PollPlus.Controllers
{
    [OnlyAuthorizedUser]
    public class EnqueteController : BaseController
    {
        readonly IEnqueteServiceWEB service;

        readonly IPerguntaRespostaServiceWEB servicePerguntaResposta;

        readonly IRespostaServiceWEB serviceResposta;

        public EnqueteController(IEnqueteServiceWEB _service, IPerguntaRespostaServiceWEB _servicePerguntaResposta,
            IRespostaServiceWEB _serviceResposta)
        {
            this.service = _service;
            this.servicePerguntaResposta = _servicePerguntaResposta;
            this.serviceResposta = _serviceResposta;
        }

        [HttpGet, OnlyAuthorizedUser]
        public ActionResult NovaEnquete()
        {
            return View();
        }

        public async Task<ActionResult> SalvaRespostas(EnqueteViewModel model, List<string> resposta)
        {
            if (!ModelState.IsValid || !resposta.Any())
                return View(model);

            var respostas = MapeiaListaDeRespostas(resposta);

            foreach (var r in respostas)
            {
                await this.serviceResposta.InserirResposta(r);
            }

            if (this.servicePerguntaResposta.InserirPerguntaResposta(MapeiaParaPerguntaResposta(model.Pergunta.Id,respsota)))

        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> NovaEnquete(EnqueteViewModel model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.EmpresaId = (int)UsuarioLogado.UsuarioAutenticado().EmpresaId;
            model.UsuarioId = UsuarioLogado.UsuarioAutenticado().Id;
            model.file = file.FileName;
            model.Tipo = UsuarioLogado.UsuarioAutenticado().Perfil == Domain.Enumeradores.EnumPerfil.AdministradorEmpresa
                ? Domain.Enumeradores.EnumTipoEnquete.Interesse
                : Domain.Enumeradores.EnumTipoEnquete.Publica;

            var enquete = await this.service.InserirRetornarEnquete(AutoMapper.Mapper.Map<Enquete>(model));

            if (enquete != null)
                return View(AutoMapper.Mapper.Map<EnqueteViewModel>(enquete));

            return View();
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> EditarEnquete(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);

            return View(AutoMapper.Mapper.Map<Enquete>(enquete));
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> EditarEnquete(EnqueteViewModel model, HttpPostedFileBase file)
        {
            model.EmpresaId = (int)UsuarioLogado.UsuarioAutenticado().EmpresaId;
            model.UsuarioId = UsuarioLogado.UsuarioAutenticado().Id;
            model.file = file.FileName;
            model.Tipo = UsuarioLogado.UsuarioAutenticado().Perfil == Domain.Enumeradores.EnumPerfil.AdministradorEmpresa
                ? Domain.Enumeradores.EnumTipoEnquete.Interesse
                : Domain.Enumeradores.EnumTipoEnquete.Publica;

            if (!ModelState.IsValid)
                return View(model);

            if (await this.service.AtualizarEnquete(AutoMapper.Mapper.Map<Enquete>(model)))
                return RedirectToAction("ListarEmpresas");

            return View(model);
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> ListarEnquetes(int? pagina)
        {
            var listaEnquetes = await this.service.RetornarTodasEnquetes();

            return View(listaEnquetes.ToPagedList(pagina ?? 1, 10));
        }

        private static IEnumerable<Resposta> MapeiaListaDeRespostas(List<string> respostas)
        {
            foreach (var resposta in respostas)
            {
                yield return new Resposta { TextoResposta = resposta };
            }
        }

        private static IEnumerable<PerguntaResposta> MapeiaParaPerguntaResposta(int perguntaId, IEnumerable<Resposta> respostas)
        {
            foreach (var resposta in respostas)
            {
                yield return new PerguntaResposta { PerguntaId = perguntaId, RespostaId = resposta.Id };
            }
        }
    }
}