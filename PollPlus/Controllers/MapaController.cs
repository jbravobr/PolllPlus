﻿using Geocoding;
using Geocoding.Google;
using Newtonsoft.Json;
using PollPlus.Domain;
using PollPlus.Filter;
using PollPlus.Models;
using PollPlus.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PollPlus.Controllers
{
    [OnlyAuthorizedUser]
    public class MapaController : BaseController
    {
        private GeolocalizacaoRepositorio geoRepo = new GeolocalizacaoRepositorio();

        private UsuarioRepositorio user = new UsuarioRepositorio();

        [HttpGet, OnlyAuthorizedUser]
        public async Task<ActionResult> Mapa()
        {
            var localizacoes = await geoRepo.RetornarTodasGeolocalizacoes();
            var dados = MontaIndicadoresNoMapaSemRadar(localizacoes);

            return View(dados);
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> Sonar(string Latitude, string Longitude, string Raio)
        {

            var localizacoes = await geoRepo.RetornarTodasGeolocalizacoes();
            var dados = MontaIndicadoresNoMapaComRadar(localizacoes);

            ViewData.Add("Lat", Convert.ToDouble(Latitude));
            ViewData.Add("Long", Convert.ToDouble(Longitude));
            ViewData.Add("Raio", Convert.ToInt32(Raio));

            return View(dados);
        }

        // GET: Mapa
        public async Task<ActionResult> Index()
        {
            var localizacoes = await geoRepo.RetornarTodasGeolocalizacoes();
            var dados = MontaIndicadoresNoMapaSemRadar(localizacoes).Take(2);

            return View(dados);
        }

        [NonAction]
        private string RetornaEndereco(double latitude, double longitude)
        {
            //IGeocoder geocoder = new GoogleGeocoder();

            //try
            //{
            //    return geocoder.ReverseGeocode(latitude, longitude).First().FormattedAddress;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            try
            {
                var key = "AIzaSyAJXiJ8FatzUwzUKOfgv3Eh9qMTlPewBu0";
                string url = "https://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&key={2}";
                url = string.Format(url, latitude.ToString().Replace(',', '.'), longitude.ToString().Replace(',', '.'), key);
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = client.GetStringAsync(new Uri(url)).Result;
                var endereco = JsonConvert.DeserializeObject<RootObject>(result);

                return endereco != null && endereco.results != null && endereco.results.Any() ?
                    endereco.results.First().formatted_address :
                    "Endereço não resolvido pelo Google";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [NonAction]
        private IEnumerable<MapViewModel> MontaIndicadoresNoMapaComRadar(ICollection<Geolocalizacao> posicoes)
        {
            var lista = new List<MapViewModel>();
            var group = posicoes.GroupBy(x => x.UsuarioId).Distinct();
            var tempo = DateTime.Now.AddDays(-180);

            foreach (var posicao in group)
            {
                foreach (var item in posicao.Where(x => x.DataCriacao >= tempo))
                {
                    yield return new MapViewModel
                    {
                        Latitude = item.Latitude,
                        Longitude = item.Longitude,
                        //Endereco = RetornaEndereco(posicao.Latitude, posicao.Longitude),
                        Nome = item.Usuario.Nome,
                        Icon = item.Usuario.Perfil == Domain.Enumeradores.EnumPerfil.AdministradorEmpresa ?
                    "IconMarkerOutrasEmpresas.png" : "IconMarkerMais.png"
                    };
                }
            }
        }

        [NonAction]
        private IEnumerable<MapViewModel> MontaIndicadoresNoMapaSemRadar(ICollection<Geolocalizacao> posicoes)
        {
            var lista = new List<MapViewModel>();

            foreach (var item in posicoes)
            {
                yield return new MapViewModel
                {
                    Latitude = item.Latitude,
                    Longitude = item.Longitude,
                    //Endereco = RetornaEndereco(posicao.Latitude, posicao.Longitude),
                    Nome = item.Usuario.Nome,
                    Icon = item.Usuario.Perfil == Domain.Enumeradores.EnumPerfil.AdministradorEmpresa ?
    "IconMarkerOutrasEmpresas.png" : item.Usuario.Perfil == Domain.Enumeradores.EnumPerfil.Vendedor ?
    "IconMarkerVendedorMais.png" : "IconMarkerMais.png"
                };
            }
        }

        private async Task<Usuario> RetornaDadosDoUsuario(int usuarioId)
        {
            return await this.user.RetornarUsuarioPorId(usuarioId);
        }

        [HttpGet, OnlyAuthorizedUser]
        public async Task<JsonResult> AtualizaContadorMapaPessoas(string Latitude, string Longitude, string Raio)
        {
            var localizacoes = await geoRepo.RetornarTodasGeolocalizacoes();

            var listaUsuario = new List<Usuario>();

            foreach (var geo in localizacoes)
            {
                if (CalcularDistancia(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude), geo.Latitude, geo.Longitude, Convert.ToInt32(Raio)))
                {
                    if (!listaUsuario.Contains(geo.Usuario))
                        listaUsuario.Add(geo.Usuario);
                }
            }
            return Json(listaUsuario.Count, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        private bool CalcularDistancia(double latOrigem, double lonOrigem, double latUsuario, double lonUsuario, double alcance)
        {
            var localOrigem = new GeoCoordinate(latOrigem, lonOrigem);
            var localUsuario = new GeoCoordinate(latUsuario, lonUsuario);

            var distancia = localOrigem.GetDistanceTo(localUsuario);

            return distancia <= alcance;
        }
    }

    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Bounds
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Northeast2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Viewport
    {
        public Northeast2 northeast { get; set; }
        public Southwest2 southwest { get; set; }
    }

    public class Geometry
    {
        public Bounds bounds { get; set; }
        public Location location { get; set; }
        public string location_type { get; set; }
        public Viewport viewport { get; set; }
    }

    public class Result
    {
        public List<AddressComponent> address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string place_id { get; set; }
        public List<string> types { get; set; }
    }

    public class RootObject
    {
        public List<Result> results { get; set; }
        public string status { get; set; }
    }
}