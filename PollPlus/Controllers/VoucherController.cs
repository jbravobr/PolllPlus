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
    public class VoucherController : Controller
    {
        readonly IVoucherServiceWEB _service;

        readonly IEmpresaServiceWEB serviceEmpresas;

        readonly IEnqueteServiceWEB serviceEnquete;

        public VoucherController(IVoucherServiceWEB service, IEmpresaServiceWEB serviceEmpresas, IEnqueteServiceWEB serviceEnquete)
        {
            this._service = service;
            this.serviceEmpresas = serviceEmpresas;
            this.serviceEnquete = serviceEnquete;
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> NovoVoucher()
        {
            if (UsuarioLogado.UsuarioAutenticado().Perfil == Domain.Enumeradores.EnumPerfil.AdministradorEmpresa)
            {
                var enquetes = await this.serviceEnquete.RetornarTodasEnquetes();
                var filtro = enquetes.Where(e => e.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId).ToList();
                ViewData.Add("EnqueteForSelectList", PreparaParaListaDeEnquetes(filtro, null));
            }
            else
            {
                var enquetes = await this.serviceEnquete.RetornarTodasEnquetes();
                ViewData.Add("EnqueteForSelectList", PreparaParaListaDeEnquetes(enquetes.Where(x=>x.PerguntaId != null).ToList(), null));
            }
            return View();
        }

        [OnlyAuthorizedUser, HttpPost]
        public async Task<ActionResult> NovoVoucher(VoucherViewModel model, string NroVoucher)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (UsuarioLogado.UsuarioAutenticado().Perfil == Domain.Enumeradores.EnumPerfil.AdministradorEmpresa)
            {
                var enquetes = await this.serviceEnquete.RetornarTodasEnquetes();
                var filtro = enquetes.Where(e => e.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId).ToList();
                ViewData.Add("EnqueteForSelectList", PreparaParaListaDeEnquetes(filtro, null));
            }
            else
            {
                var enquetes = await this.serviceEnquete.RetornarTodasEnquetes();
                ViewData.Add("EnqueteForSelectList", PreparaParaListaDeEnquetes(enquetes, null));
            }

            foreach (var item in NroVoucher.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                var v = new Voucher { DataValidade = model.DataValidade, Identificador = item, Status = Domain.Enumeradores.EnumStatusVoucher.Disponivel, Usado = false };
                var voucher = await this._service.InserirRetornarVoucher(v);
                if (voucher != null)
                    await this._service.AssociaVoucherEnquete(model.EnqueteId, voucher.Id);
            }

            return RedirectToAction("ListarVouchers", "Voucher");
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
                return RedirectToAction("ListarVouchers");

            return View(model);
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> ListarVouchers(int? pagina)
        {
            var lista = await this._service.RetornarTodosVouchers();
            var listaEnquete = new List<Enquete>();

            foreach (var item in lista)
            {
                foreach (var e in item.EnqueteVoucher)
                {
                    listaEnquete.Add(await this.serviceEnquete.RetornarEnquetePorId(e.EnqueteId));
                }
            }

            foreach (var item in lista.SelectMany(x => x.EnqueteVoucher))
            {
                item.Enquete = listaEnquete.First(x => x.Id == item.EnqueteId);
            }

            if (listaEnquete.Any())
                ViewBag.Enquetes = listaEnquete;

            return View(lista.ToPagedList(pagina ?? 1, 10));
        }

        [OnlyAuthorizedUser, HttpGet]
        public async Task<ActionResult> MarcarComoUtilizado(int voucherId)
        {
            var voucher = await this._service.RetornarVoucherPorId(voucherId);
            voucher.Usado = true;
            voucher.Status = Domain.Enumeradores.EnumStatusVoucher.Indisponivel;

            await this._service.AtualizarVoucher(voucher);

            return RedirectToAction("ListarVouchers");
        }

        [NonAction]
        private static IEnumerable<SelectListItem> PreparaParaListaDeEnquetes(ICollection<Enquete> enquetes, int? enqueteSelecionada = null)
        {
            foreach (var enquete in enquetes)
            {
                if (enqueteSelecionada != null)
                {
                    yield return new SelectListItem
                    {
                        Text = enquete.Pergunta.TextoPergunta,
                        Value = enquete.Id.ToString(),
                        Selected = enquete.Id == enqueteSelecionada
                    };
                }

                yield return new SelectListItem
                {
                    Text = enquete.Pergunta.TextoPergunta,
                    Value = enquete.Id.ToString()
                };
            }
        }
    }
}