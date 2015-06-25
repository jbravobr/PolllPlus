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

namespace PollPlus.Controllers
{
    [OnlyAuthorizedUser]
    public class BannerController : BaseController
    {
        readonly IBannerServiceWEB service;

        public BannerController(IBannerServiceWEB srv)
        {
            this.service = srv;
        }

        [HttpGet]
        public ActionResult NovoBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> NovoBanner(BannerViewModel model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.EmpresaId = (int)UsuarioLogado.UsuarioAutenticado().EmpresaId;
            if (await this.service.InserirBanner(AutoMapper.Mapper.Map<Banner>(model)))
            {
                if (file.ContentLength > 0)
                    if (Util.SalvarImagem(file))
                        return View("ListarBanners");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> ListarBanners(int? pagina)
        {
            var lista = await this.service.RetornarTodosBanners();

            return View(lista.ToPagedList(pagina ?? 1, 10));
        }
    }
}