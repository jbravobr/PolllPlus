using PagedList;
using PollPlus.Domain;
using PollPlus.Filter;
using PollPlus.Helpers;
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

        readonly IUsuarioServiceWEB serviceUsuario;

        readonly IPerguntaServiceWEB servicePergunta;

        readonly IRespostaServiceWEB serviceResposta;

        readonly IBlackListServiceWEB serviceBlackList;

        public EnqueteController(IEnqueteServiceWEB _service, IPerguntaServiceWEB _servicePergunta,
            IRespostaServiceWEB _serviceResposta, IBlackListServiceWEB _serviceBlackList, IUsuarioServiceWEB _serviceUsuario)
        {
            this.service = _service;
            this.servicePergunta = _servicePergunta;
            this.serviceResposta = _serviceResposta;
            this.serviceBlackList = _serviceBlackList;
            this.serviceUsuario = _serviceUsuario;
        }

        public EnqueteController() { }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> NovaEnquete()
        {
            var categorias = await this.serviceUsuario.RetornarCategoriasDisponniveis();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, null));

            return View();
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> SalvaRespostas(PerguntaViewModel Pergunta, List<string> resposta)
        {
            if (!ModelState.IsValid || !resposta.Any())
                return View(Pergunta);

            var respostas = MapeiaListaDeRespostas(resposta, Pergunta.Id);

            foreach (var r in respostas)
            {
                await this.serviceResposta.InserirResposta(r);
            }

            return RedirectToAction("ListarEnquetes");
        }

        [HttpGet, OnlyAuthorizedUser]
        public ActionResult ImportarBlackList()
        {
            return View();
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> ImportarBlackList(HttpPostedFileBase file)
        {
            if (file.ContentLength <= 0)
                return View(0);

            try
            {
                var blacklist = (ICollection<BlackList>)Util.ImportarCSV(EnumTipoImportacao.Blacklist, file);

                foreach (var item in blacklist)
                {
                    await this.serviceBlackList.InserirBlackList(item);
                }

                return View(1);
            }
            catch (Exception ex)
            {
                return View(0);
            }
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> NovaEnquete(EnqueteViewModel model, HttpPostedFileBase file)
        {
            var categorias = await this.serviceUsuario.RetornarCategoriasDisponniveis();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, null));

            if (!ModelState.IsValid)
                return View(model);

            model.Status = Domain.Enumeradores.EnumStatusEnquete.Ativa;
            var enquete = await this.service.InserirRetornarEnquete(AutoMapper.Mapper.Map<Enquete>(model));

            if (enquete != null)
            {
                if (file !=null && file.ContentLength > 0)
                    Util.SalvarImagem(file);

                enquete.AdicionarCategoria(model.CategoriasInteresse);

                foreach (var uc in enquete.EnqueteCategoria)
                {
                    await service.InserirEnqueteCategoria(uc);
                }

                return View(AutoMapper.Mapper.Map<EnqueteViewModel>(enquete));

            }

            return View();
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> EditarEnquete(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);

            var respostas = enquete.Pergunta.Resposta;

            if (respostas != null && respostas.Any())
                ViewData.Add("Respostas", AutoMapper.Mapper.Map<ICollection<RespostaViewModel>>(respostas));

            return View(AutoMapper.Mapper.Map<EnqueteViewModel>(enquete));
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> EditarEnquete(EnqueteViewModel model, HttpPostedFileBase file)
        {
            var respostas = model.Pergunta.Resposta;

            if (respostas != null && respostas.Any())
                ViewData.Add("Respostas", AutoMapper.Mapper.Map<RespostaViewModel>(respostas));

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

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> PublicarEnquete(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);
            enquete.Status = Domain.Enumeradores.EnumStatusEnquete.Publicada;

            await this.service.AtualizarEnquete(enquete);
            return Redirect("ListarEnquetes");
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> DespublicarEnquete(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);
            enquete.Status = Domain.Enumeradores.EnumStatusEnquete.Despublicada;

            await this.service.AtualizarEnquete(enquete);
            return Redirect("ListarEnquetes");
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> AtivarEnquete(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);
            enquete.Status = Domain.Enumeradores.EnumStatusEnquete.Ativa;

            await this.service.AtualizarEnquete(enquete);
            return Redirect("ListarEnquetes");
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> DesativarEnquete(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);
            enquete.Status = Domain.Enumeradores.EnumStatusEnquete.Inativa;

            await this.service.AtualizarEnquete(enquete);
            return Redirect("ListarEnquetes");
        }

        private static IEnumerable<Resposta> MapeiaListaDeRespostas(List<string> respostas, int perguntaId)
        {
            foreach (var resposta in respostas)
            {
                yield return new Resposta { TextoResposta = resposta, PerguntaId = perguntaId };
            }
        }

        [NonAction]
        private static IEnumerable<SelectListItem> PreparaParaListaDeCategorias(ICollection<Categoria> categorias, List<int> categoriaSelecionada = null)
        {
            foreach (var categoria in categorias)
            {
                if (categoriaSelecionada != null)
                {
                    yield return new SelectListItem
                    {
                        Text = categoria.Nome,
                        Value = categoria.Id.ToString(),
                        Selected = categoriaSelecionada.Contains((int)categoria.Id)
                    };
                }

                yield return new SelectListItem
                {
                    Text = categoria.Nome,
                    Value = categoria.Id.ToString()
                };
            }
        }
    }
}