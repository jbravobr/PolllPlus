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
    }
}