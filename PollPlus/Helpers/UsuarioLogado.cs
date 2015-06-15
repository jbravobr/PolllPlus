using PollPlus.Controllers;
using PollPlus.Domain;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PollPlus.Helpers
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
        /// Remove o registro do usuário da sessão logada
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
