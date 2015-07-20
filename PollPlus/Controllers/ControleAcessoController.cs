using PollPlus.Domain;
using PollPlus.Domain.Enumeradores;
using PollPlus.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PollPlus.Filter;
using PollPlus.Service.Interfaces;

namespace PollPlus.Controllers
{
    [OnlyAuthorizedUser]
    public class ControleAcessoController : Controller
    {
        private ControleAcessoRepositorio repo = new ControleAcessoRepositorio();
        readonly IEmpresaServiceWEB service;

        public ControleAcessoController(IEmpresaServiceWEB service)
        {
            this.service = service;
        }

        // GET: ControleAcesso
        [HttpGet]
        public async Task<ActionResult> NovoControleAcesso()
        {
            var empresas = await this.service.RetornarTodasEmpresas();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, null));

            ViewData.Add("AcessosEnum", PreparaParaListaDeTiposAcesso());

            return View();
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

        [NonAction]
        private static IEnumerable<SelectListItem> PreparaParaListaDeTiposAcesso()
        {
            foreach (EnumAreaAcesso item in Enum.GetValues(typeof(EnumAreaAcesso)))
            {
                yield return new SelectListItem { Text = item.GetDescription(), Value = ((int)(item)).ToString() };
            }
        }

        [HttpPost]
        public async Task<ActionResult> NovoControleAcesso(int empresaId, int tipoAcesso)
        {
            var empresas = await this.service.RetornarTodasEmpresas();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, null));

            ViewData.Add("AcessosEnum", PreparaParaListaDeTiposAcesso());

            var _enumAcesso = (EnumAreaAcesso)Enum.Parse(typeof(EnumAreaAcesso), tipoAcesso.ToString());
            var _acesso = new ControleAcesso { EmpresaId = empresaId, AreaAcesso = _enumAcesso };

            if (await this.repo.InserirNovoControleAcesso(_acesso))
                return RedirectToAction("ListarControlesAcessos");

            return View("Index");
        }

        [HttpGet]
        public async Task<ActionResult> ListarControlesAcessos(int? page)
        {
            var lista = await this.repo.RetornarTodosControleAcesso();

            return View(lista.ToPagedList(page ?? 1, 10));
        }
    }
}