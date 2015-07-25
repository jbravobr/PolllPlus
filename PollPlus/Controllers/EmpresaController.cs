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
using PagedList;
using PollPlus.Repositorio;

namespace PollPlus.Controllers
{
    [OnlyAuthorizedUser]
    public class EmpresaController : BaseController
    {
        readonly IEmpresaServiceWEB service;
        private FilialRepositorio repoFilial = new FilialRepositorio();

        public EmpresaController(IEmpresaServiceWEB _service)
        {
            this.service = _service;
        }

        [OnlyAuthorizedUser, HttpGet]
        public ActionResult NovaEmpresa()
        {
            return View();
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> NovaEmpresa(EmpresaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            else if (await this.service.InserirEmpresa(AutoMapper.Mapper.Map<Empresa>(model)))
                return RedirectToAction("ListarEmpresas");

            return View(model);
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> RemoverEmpresa(int empresaId)
        {
            var acao = await this.service.DeletarEmpresa(await this.service.RetornarEmpresaPorId(empresaId));
            return RedirectToAction("ListarEmpresas");
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> EditarEmpresa(int empresaId)
        {
            var empresa = await this.service.RetornarEmpresaPorId(empresaId);

            return View(AutoMapper.Mapper.Map<EmpresaViewModel>(empresa));
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> EditarEmpresa(EmpresaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            else if (await this.service.AtualizarEmpresa(AutoMapper.Mapper.Map<Empresa>(model)))
                return RedirectToAction("ListarEmpresas");

            return View(model);
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> ListarEmpresas(int? pagina)
        {
            var listarEmpresas = await this.service.RetornarTodasEmpresas();

            return View(listarEmpresas.ToPagedList(pagina ?? 1, 10));
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> NovaFilial()
        {
            var empresas = await this.service.RetornarTodasEmpresas();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, null));
            return View();
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> NovaFilial(FilialViewModel model)
        {
            var empresas = await this.service.RetornarTodasEmpresas();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, null));

            if (!ModelState.IsValid)
            {
                ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, null));
                return View(model);
            }
            else if (await this.repoFilial.InserirFilial(AutoMapper.Mapper.Map<Filial>(model)))
                return RedirectToAction("ListarFiliais");

            return View(model);
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> ListarFiliais(int? pagina)
        {
            var listaFiliais = await this.repoFilial.RetornarTodasFiliais();

            return View(listaFiliais.OrderByDescending(x=>x.DataCriacao).ToPagedList(pagina ?? 1, 10));
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

                yield return new SelectListItem
                {
                    Text = empresa.Nome,
                    Value = empresa.Id.ToString()
                };
            }
        }
    }
}