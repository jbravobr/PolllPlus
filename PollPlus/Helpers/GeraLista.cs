using PollPlus.Domain;
using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace PollPlus.Helpers
{
    public static class GeraLista
    {
        public static MvcHtmlString DeSexos(this HtmlHelper html)
        {
            return html.DropDownList("Sexo", MontaListaDeSexos(), "Selecione uma opção");
        }

        public static MvcHtmlString DeCategorias(this HtmlHelper html, ICollection<Categoria> Categorias, int? selecionado= null)
        {
            return html.DropDownList("CategoriasInteresse", MontaListaDeCategorias(Categorias), "Selecione uma opção");
        }

        #region -- DATA SOURCES --

        private static IEnumerable<SelectListItem> MontaListaDeSexos()
        {
            foreach (EnumSexo _sexo in Enum.GetValues(typeof(EnumSexo)))
            {
                yield return new SelectListItem { Text = _sexo.GetDescription() , Value = Convert.ToString((int)_sexo) };
            }
        }

        private static IEnumerable<SelectListItem> MontaListaDeCategorias(ICollection<Categoria> Categorias, int? selecionado = null)
        {
            foreach (Categoria cat in Categorias)
            {
                yield return new SelectListItem { Text = cat.Nome, Value = cat.Id.ToString(), Selected = cat.Id == selecionado };
            }
        }

        #endregion
    }
}
