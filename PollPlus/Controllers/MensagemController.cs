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
    public class MensagemController : BaseController
    {
        readonly IEnqueteServiceWEB service;

        readonly IUsuarioServiceWEB serviceUsuario;

        readonly IPerguntaServiceWEB servicePergunta;

        readonly IRespostaServiceWEB serviceResposta;

        readonly IBlackListServiceWEB serviceBlackList;

        public MensagemController(IEnqueteServiceWEB _service, IPerguntaServiceWEB _servicePergunta,
            IRespostaServiceWEB _serviceResposta, IBlackListServiceWEB _serviceBlackList, IUsuarioServiceWEB _serviceUsuario)
        {
            this.service = _service;
            this.servicePergunta = _servicePergunta;
            this.serviceResposta = _serviceResposta;
            this.serviceBlackList = _serviceBlackList;
            this.serviceUsuario = _serviceUsuario;
        }

        public MensagemController() { }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> NovaMensagem()
        {
            var categorias = await this.serviceUsuario.RetornarCategoriasDisponniveis();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, null));

            return View();
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> NovaMensagem(EnqueteViewModel model, HttpPostedFileBase file, List<string> resposta)
        {
            var categorias = await this.serviceUsuario.RetornarCategoriasDisponniveis();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, null));

            if (!ModelState.IsValid)
                return View(model);

            model.Status = Domain.Enumeradores.EnumStatusEnquete.Ativa;
            var enquete = await this.service.InserirRetornarEnquete(AutoMapper.Mapper.Map<Enquete>(model));

            if (enquete != null)
            {
                if (file != null && file.ContentLength > 0)
                    Util.SalvarImagem(file);

                enquete.AdicionarCategoria(model.CategoriasInteresse);

                foreach (var uc in enquete.EnqueteCategoria)
                {
                    await service.InserirEnqueteCategoria(uc);
                }

                return RedirectToAction("ListarMensagens");
            }

            return View();
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> EditarMensagem(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);

            var mapper = AutoMapper.Mapper.Map<EnqueteViewModel>(enquete);

            var categorias = await this.serviceUsuario.RetornarCategoriasDisponniveis();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, mapper.CategoriasInteresse));

            return View(mapper);
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> EditarMensagem(EnqueteViewModel model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (await this.service.AtualizarEnquete(AutoMapper.Mapper.Map<Enquete>(model)))
                return RedirectToAction("ListarMensagens");

            return View(model);
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> ListarMensagens(int? pagina)
        {
            var listaEnquetes = await this.service.RetornarTodasEnquetes();

            return View(listaEnquetes.Where(x => x.Tipo == Domain.Enumeradores.EnumTipoEnquete.Mensagem).ToPagedList(pagina ?? 1, 10));
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> PublicarEnquete(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);
            enquete.Status = Domain.Enumeradores.EnumStatusEnquete.Publicada;

            await this.service.AtualizarEnquete(enquete);
            return Redirect("ListarMensagens");
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> DespublicarEnquete(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);
            enquete.Status = Domain.Enumeradores.EnumStatusEnquete.Despublicada;

            await this.service.AtualizarEnquete(enquete);
            return Redirect("ListarMensagens");
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> AtivarEnquete(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);
            enquete.Status = Domain.Enumeradores.EnumStatusEnquete.Ativa;

            await this.service.AtualizarEnquete(enquete);
            return Redirect("ListarMensagens");
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> DesativarEnquete(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);
            enquete.Status = Domain.Enumeradores.EnumStatusEnquete.Inativa;

            await this.service.AtualizarEnquete(enquete);
            return Redirect("ListarMensagens");
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