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

        public EnqueteController(IEnqueteServiceWEB _service)
        {
            this.service = _service;
        }

        [HttpGet, OnlyAuthorizedUser]
        public ActionResult NovaEnquete()
        {
            return View();
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> NovaEnquete(EnqueteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (await this.service.InserirEnquete(AutoMapper.Mapper.Map<Enquete>(model)))
                return RedirectToAction("ListarEmpresas");

            return View();
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> EditarEnquete(int enqueteId)
        {
            var enquete = await this.service.RetornarEnquetePorId(enqueteId);

            return View(AutoMapper.Mapper.Map<Enquete>(enquete));
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> EditarEnquete(EnqueteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (await this.service.AtualizarEnquete(AutoMapper.Mapper.Map<Enquete>(model)))
                return RedirectToAction("ListarEmpresas");

            return View(model);
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> ListarEmpresas(int? pagina)
        {
            var listaEnquetes = await this.service.RetornarTodasEnquetes();

            return View(listaEnquetes.ToPagedList(pagina ?? 1, 10));
        }
    }
}