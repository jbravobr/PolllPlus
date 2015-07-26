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
using PagedList;
using PollPlus.Repositorio;

namespace PollPlus.Controllers
{
    [OnlyAuthorizedUser]
    public class BannerController : BaseController
    {
        readonly IBannerServiceWEB service;
        readonly IEmpresaServiceWEB serviceEmpresas;
        readonly IEnqueteServiceWEB serviceEnquete;

        private CategoriaBannerRepositorio catBanner = new CategoriaBannerRepositorio();
        private EmpresaBannerRepositorio empBanner = new EmpresaBannerRepositorio();

        public BannerController(IBannerServiceWEB srv, IEmpresaServiceWEB serviceEmpresa, IEnqueteServiceWEB srvEnquete)
        {
            this.service = srv;
            this.serviceEmpresas = serviceEmpresa;
            this.serviceEnquete = srvEnquete;
        }

        [HttpGet, OnlyAuthorizedUser]
        public async Task<ActionResult> NovoBanner()
        {
            var categorias = await this.serviceEnquete.RetornarCategoriasDisponniveis();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, null));

            var empresas = await this.serviceEmpresas.RetornarTodasEmpresas();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, null));
            return View();
        }

        [HttpGet, OnlyAuthorizedUser]
        public async Task<ActionResult> EditarBanner(int bannerId)
        {
            var banner = await this.service.RetornarBannerPorId(bannerId);

            var categorias = await this.serviceEnquete.RetornarCategoriasDisponniveis();
            var b = banner.CategoriaBanner.Select(x => x.CategoriaId).ToList();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, b));

            var empresas = await this.serviceEmpresas.RetornarTodasEmpresas();
            var e = banner.EmpresaBanner.Select(x => x.EmpresaId).First();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, e));

            return View(AutoMapper.Mapper.Map<BannerViewModel>(banner));
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> EditarBanner(BannerViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if(await this.service.AtualizarBanner(AutoMapper.Mapper.Map<Banner>(model)))
                {
                    if (file.ContentLength > 0)
                        if (Util.SalvarImagem(file))
                            return RedirectToAction("ListarBanners");
                }
            }

            return View(model);
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> NovoBanner(BannerViewModel model, HttpPostedFileBase file)
        {
            var categorias = await this.serviceEnquete.RetornarCategoriasDisponniveis();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, null));

            var empresas = await this.serviceEmpresas.RetornarTodasEmpresas();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, null));
            if (!ModelState.IsValid)
                return View(model);

            if (UsuarioLogado.UsuarioAutenticado().Perfil == Domain.Enumeradores.EnumPerfil.AdministradorEmpresa)
                model.EmpresaId = (int)UsuarioLogado.UsuarioAutenticado().EmpresaId;

            model.fileName = file.FileName;
            var ban = await this.service.InserirRetornarBanner(AutoMapper.Mapper.Map<Banner>(model));
            if (ban != null)
            {
                if (model.Empresas != null)
                {
                    foreach (var item in model.Empresas)
                    {
                        await this.empBanner.InserirCB(new EmpresaBanner { EmpresaId = item, BannerId = ban.Id });
                    }
                }

                if (model.Categorias != null)
                {
                    foreach (var item in model.Categorias)
                    {
                        await this.catBanner.InserirCB(new CategoriaBanner { CategoriaId = item, BannerId = ban.Id });
                    }
                }

                if (file.ContentLength > 0)
                    if (Util.SalvarImagem(file))
                        return RedirectToAction("ListarBanners");
            }

            return View(model);
        }

        [HttpGet, OnlyAuthorizedUser]
        public async Task<ActionResult> ListarBanners(int? pagina)
        {
            var lista = await this.service.RetornarTodosBanners();

            return View(lista.OrderByDescending(x => x.DataCriacao).ToPagedList(pagina ?? 1, 10));
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> DesativarBanner(int bannerId)
        {
            var banner = await this.service.RetornarBannerPorId(bannerId);
            banner.Status = Domain.Enumeradores.EnumStatusUsuario.Inativo;

            await this.service.AtualizarBanner(banner);

            return RedirectToAction("ListarBanners");
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> AtivarBanner(int bannerId)
        {
            var banner = await this.service.RetornarBannerPorId(bannerId);
            banner.Status = Domain.Enumeradores.EnumStatusUsuario.Ativo;

            await this.service.AtualizarBanner(banner);

            return RedirectToAction("ListarBanners");
        }

        [NonAction]
        private static IEnumerable<SelectListItem> PreparaParaListaDeEmpresas(ICollection<Empresa> empresas, int? empresaSelecionada = null)
        {
            foreach (var empresa in empresas)
            {
                if (empresaSelecionada != null)
                {
                    yield return new SelectListItem
                    {
                        Text = empresa.Nome,
                        Value = empresa.Id.ToString(),
                        Selected = empresa.Id == empresaSelecionada
                    };
                }
                else
                {
                    yield return new SelectListItem
                    {
                        Text = empresa.Nome,
                        Value = empresa.Id.ToString()
                    };
                }
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
                else
                {
                    yield return new SelectListItem
                    {
                        Text = categoria.Nome,
                        Value = categoria.Id.ToString()
                    };
                }
            }
        }
    }
}