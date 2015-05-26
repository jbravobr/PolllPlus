using PollPlus.Controllers;
using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PollPlus.Models
{
    /// <summary>
    /// Classe para controle da Sessão e Usuário logado
    /// </summary>
    public abstract class UsuarioLogado
    {
        private static bool IsMenuCarregado { get; set; }

        /// <summary>
        /// Registra o usuário logado corretamente na sessão do Sistema
        /// </summary>
        /// <returns></returns>
        public static Usuario UsuarioAutenticado()
        {
            if (HttpContext.Current.Session["UsuarioLogado"] != null)
                return (Usuario)HttpContext.Current.Session["UsuarioLogado"];

            var routeData = new RouteData();
            routeData.Values["controller"] = "Account";
            routeData.Values["action"] = "Login";
            HttpContext.Current.Response.StatusCode = 500;
            IController controller = new AccountController();
            var rc = new RequestContext(new HttpContextWrapper(HttpContext.Current), routeData);
            controller.Execute(rc);

            return null;
        }

        /// <summary>
        /// Desregisra o usuário da sessão logada
        /// </summary>
        public static void Logout()
        {
            HttpContext.Current.Session.Remove("UsuarioLogado");
        }

        /// <summary>
        /// Registra o carregamento do Menu para não carregar em todas as chamadas
        /// </summary>
        public static void MenuCarregado()
        {
            IsMenuCarregado = true;
        }
    }
}
