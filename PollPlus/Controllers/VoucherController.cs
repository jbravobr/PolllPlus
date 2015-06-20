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
    public class VoucherController : Controller
    {
        readonly IVoucherServiceWEB _service;

        public VoucherController(IVoucherServiceWEB service)
        {
            this._service = service;
        }

        [OnlyAuthorizedUser, HttpGet]
        public ActionResult NovoVoucher()
        {
            return View();
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> NovoVoucher(VoucherViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (await this._service.InserirVoucher(AutoMapper.Mapper.Map<Voucher>(model)))
                return View("ListarVouchers");

            return View(model);
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> EditarVoucher(int voucherId)
        {
            var voucher = await this._service.RetornarVoucherPorId(voucherId);

            return View(AutoMapper.Mapper.Map<VoucherViewModel>(voucher));
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> EditarVoucher(VoucherViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (await this._service.AtualizarVoucher(AutoMapper.Mapper.Map<Voucher>(model)))
                return View("ListarVouchers");

            return View(model);
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> ListarVouchers(int? pagina)
        {
            var lista = await this._service.RetornarTodosVouchers();

            return View(lista.ToPagedList(pagina ?? 1, 10));
        }
    }
}