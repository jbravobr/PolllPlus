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
    public class BannerController : Controller
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

            if (await this.service.InserirBanner(AutoMapper.Mapper.Map<Banner>(model)))
            {
                if (file.ContentLength > 0)
                    if (Util.SalvarImagem(file))
                        return View("ListarBanners");
            }

            return View(model);
        }
    }
}