using PollPlus.Filter;
using PollPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PollPlus.Controllers
{
    [OnlyAuthorizedUser]
    public class MapaController : BaseController
    {
        // GET: Mapa
        public ActionResult Index()
        {
            return View(MontaIndicadoresNoMapa());
        }

        private IEnumerable<MapViewModel> MontaIndicadoresNoMapa()
        {
            var listaEndereco = new List<MapViewModel>();

            listaEndereco.Add(new MapViewModel
            {
                Endereco = "Rua Maia de Lacerda, 186",
                Latitude = -22.9159494,
                Longitude = -43.2056834,
                Icon = "IconMarkerMais.png",
                Nome = "Rodrigo"
            });

            listaEndereco.Add(new MapViewModel
            {
                Endereco = "Praça 22 de Abril, 36",
                Latitude = -22.9101457,
                Longitude = -43.1685112,
                Icon = "IconMarkerMais.png",
                Nome = "Rodrigo"
            });

            listaEndereco.Add(new MapViewModel
            {
                Endereco = "Praça 22 de Abril, 36",
                Latitude = -22.9101457,
                Longitude = -43.1685112,
                Icon = "IconMarkerMais.png",
                Nome = "Nathalia"
            });

            listaEndereco.Add(new MapViewModel
            {
                Endereco = "Avenida das Américas, 500",
                Latitude = -23.0035499,
                Longitude = -43.3175759,
                Icon = "IconMarkerOutrasEmpresas.png",
                Nome = "Alexandre"
            });

            return listaEndereco.AsEnumerable();
        }
    }
}