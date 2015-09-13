using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PollPlus.Controllers
{
    public class MenuController : BaseController
    {
        public PartialViewResult MontaMenuEnquetes()
        {
            return PartialView("_MenuEnquetes");
        }

        public PartialViewResult MontaMenuMensagens()
        {
            return PartialView("_MenuMensagens");
        }

        public PartialViewResult MontaMenuUsuarios()
        {
            return PartialView("_MenuUsuarios");
        }

        public PartialViewResult MontaMenuEmpresas()
        {
            return PartialView("_MenuEmpresas");
        }

        public PartialViewResult MontaMenuBanners()
        {
            return PartialView("_MenuBanners");
        }

        public PartialViewResult MontaMenuVouchers()
        {
            return PartialView("_MenuVouchers");
        }

        public PartialViewResult MontaMenuMapa()
        {
            return PartialView("_MenuMapas");
        }

        public PartialViewResult MontaMenuCategoria()
        {
            return PartialView("_MenuCategoria");
        }

        public PartialViewResult MontaRelatorio()
        {
            return PartialView("_MenuRelatorio");
        }

        public PartialViewResult MontaControleAcesso()
        {
            return PartialView("_MenuControleAcesso");
        }

        public PartialViewResult MontaPush()
        {
            return PartialView("_MenuPush");
        }

        public PartialViewResult MontaMenuQuiz()
        {
            return PartialView("_MenuQuiz");
        }
    }
}