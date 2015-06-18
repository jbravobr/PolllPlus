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

namespace PollPlus.Controllers
{
    [OnlyAuthorizedUser]
    public class EmpresaController : BaseController
    {
        readonly IEmpresaServiceWEB service;

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
    }
}