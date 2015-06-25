using PollPlus.Domain.Enumeradores;
using PollPlus.Helpers;
using PollPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetroRio.Comercial.Vendas.Web.Filters
{
    /// <summary>
    /// Somente para validação e montagem dos menus
    /// </summary>
    public class CustomMenuActionFilter : ActionFilterAttribute
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
                    case EnumPerfil.AdministradorEmpresa:
                        Autorizado = IsAdministradorEmpresa();
                        break;
                    case EnumPerfil.AdministradorMaster:
                        Autorizado = IsAdministradorMaster();
                        break;
                }
                
                if (Autorizado)
                    break;
            }

            if (!Autorizado)
                filterContext.Result = new ContentResult { Content = string.Empty };
        }

        # region -- MÉTODOS PRIVADOS --

        private bool IsAdministradorMaster()
        {
            return UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorMaster;
        }

        private bool IsAdministradorEmpresa()
        {
            return UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorEmpresa;
        }

        #endregion
    }
}