using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using PollPlus.Domain.Enumeradores;
using PollPlus.Models;
using PollPlus.Helpers;

namespace PollPlus.Filters
{
    public sealed class CustomActionFilter : ActionFilterAttribute
    {
        public EnumPerfil[] PerfilAutorizado { get; set; }
        private bool Autorizado { get; set; }

        /// <summary>
        /// Valida antes da execução da action se o usuário possui o perfil necessário para a ação
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Autorizado = false;

            foreach (var _perfil in PerfilAutorizado.ToList())
            {
                switch (_perfil)
                {
                    case EnumPerfil.AdministradorMaster:
                        Autorizado = IsAdministradorMaster();
                        break;
                    case EnumPerfil.AdministradorEmpresa:
                        Autorizado = IsAdministradorEmpresa();
                        break;
                }

                if (Autorizado)
                    break;
            }

            if (!Autorizado)
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { action = "NaoAutorizado", controller = "Account" }));
        }

        # region -- MÉTODOS PRIVADOS --

        private static bool IsAdministradorMaster()
        {
            return UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorMaster;
        }

        private static bool IsAdministradorEmpresa()
        {
            return UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorEmpresa;
        }

        #endregion
    }
}