using Geocoding;
using Geocoding.Google;
using Newtonsoft.Json;
using PollPlus.Domain;
using PollPlus.Filter;
using PollPlus.Models;
using PollPlus.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
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

        // GET: Mapa
        public async Task<ActionResult> Index()
        {
            var localizacoes = await geoRepo.RetornarTodasGeolocalizacoes();
            var dados = MontaIndicadoresNoMapa(localizacoes);

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


            var key = "AIzaSyAJXiJ8FatzUwzUKOfgv3Eh9qMTlPewBu0";
            string url = "https://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&key={2}";
            url = string.Format(url, latitude.ToString().Replace(',', '.'), longitude.ToString().Replace(',', '.'), key);
            HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(3);

            var result = client.GetStringAsync(new Uri(url)).Result;
            var endereco = JsonConvert.DeserializeObject<RootObject>(result);

            return endereco.results.First().formatted_address;
        }

        [NonAction]
        private IEnumerable<MapViewModel> MontaIndicadoresNoMapa(ICollection<Geolocalizacao> posicoes)
        {
            var lista = new List<MapViewModel>();

            foreach (var posicao in posicoes.Distinct())
            {
                yield return new MapViewModel
                {
                    Latitude = posicao.Latitude,
                    Longitude = posicao.Longitude,
                    Endereco = RetornaEndereco(posicao.Latitude, posicao.Longitude),
                    Nome = posicao.Usuario.Nome,
                    Icon = posicao.Usuario.Perfil == Domain.Enumeradores.EnumPerfil.AdministradorEmpresa ?
                    "IconMarkerOutrasEmpresas.png" : "IconMarkerMais.png"
                };
            }
        }

        private async Task<Usuario> RetornaDadosDoUsuario(int usuarioId)
        {
            return await this.user.RetornarUsuarioPorId(usuarioId);
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