using Geocoding;
using Geocoding.Google;
using PollPlus.Domain;
using PollPlus.Filter;
using PollPlus.Models;
using PollPlus.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var dados =  MontaIndicadoresNoMapa(localizacoes);

            return View(dados);
        }

        [NonAction]
        private string RetornaEndereco(double latitude, double longitude)
        {
            IGeocoder geocoder = new GoogleGeocoder();

            try
            {
                return geocoder.ReverseGeocode(latitude, longitude).First().FormattedAddress;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [NonAction]
        private IEnumerable<MapViewModel>MontaIndicadoresNoMapa(ICollection<Geolocalizacao> posicoes)
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
}