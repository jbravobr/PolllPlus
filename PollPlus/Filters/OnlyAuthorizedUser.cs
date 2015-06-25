using PollPlus.Helpers;
using PollPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PollPlus.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class OnlyAuthorizedUser : AuthorizeAttribute
    {
        protected Boolean _tratarComoExcecao;

        public OnlyAuthorizedUser(Boolean p_excecao = false)
        {
            this._tratarComoExcecao = p_excecao;
        }

        /// <summary>
        /// Usado para validar se um usuário está com login válido no sistema, para uso do mesmo
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (this._tratarComoExcecao)
                return true;

            return UsuarioLogado.UsuarioAutenticado() != null;
        }

        /// <summary>
        /// Usado para redirecionar o usuário para a página de login em caso do mesmo não estar logado 
        /// (login válido) no sistema.
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary(new { action = "Login", controller = "Account" })
            );
        }
    }
}