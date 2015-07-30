using PollPlus.Domain;
using PollPlus.Filter;
using PollPlus.Helpers;
using PollPlus.Models;
using PollPlus.Repositorio;
using PollPlus.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PollPlus.Controllers
{
    [OnlyAuthorizedUser]
    public class PushController : BaseController
    {
        private UsuarioRepositorio usuarioRepo = new UsuarioRepositorio();
        private GeolocalizacaoRepositorio geoRepositorio = new GeolocalizacaoRepositorio();
        private EmpresaRepositorio empresaRepositorio = new EmpresaRepositorio();

        [HttpGet, OnlyAuthorizedUser]
        public ActionResult NovoPush()
        {
            return View();
        }

        [HttpGet, OnlyAuthorizedUser]
        public ActionResult NovoPushPorArea()
        {
            return View();
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> NovoPush(NovaMensagemPushViewModel p_mensagem)
        {
            if (!ModelState.IsValid)
                return View(p_mensagem);

            var _empresa = await this.empresaRepositorio.RetornarEmpresaPorId((int)UsuarioLogado.UsuarioAutenticado().EmpresaId);

            if (_empresa.QtdePush > 0)
            {
                var _retornoPushWoosh = EnvioPushWooshResult(p_mensagem);

                if (_retornoPushWoosh)
                {
                    _empresa.QtdePush = _empresa.QtdePush - 1;
                    await this.empresaRepositorio.AtualizarEmpresa(_empresa);
                }
            }

            return View();
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> NovoPushPorArea(NovaMensagemPushViewModel p_mensagem)
        {
            if (ModelState.IsValid)
            {
                var empresa = (int)UsuarioLogado.UsuarioAutenticado().EmpresaId;

                var geoCollection = await this.geoRepositorio.RetornarGeoPorUsuarioPorEmpresa(empresa);

                var geoValidas = new List<string>();

                foreach (var geo in geoCollection)
                {
                    if (distance(p_mensagem.Latitude, p_mensagem.Longitude, geo.Latitude, geo.Longitude, 'K', p_mensagem.Area))
                    {
                        geoValidas.Add(geo.Usuario.PushWooshToken);
                    }
                }

                if (geoValidas.Any())
                {
                    var _empresa = await this.empresaRepositorio.RetornarEmpresaPorId((int)UsuarioLogado.UsuarioAutenticado().EmpresaId);

                    if (_empresa.QtdePush > 0 && _empresa.QtdePush <= geoValidas.Count)
                    {
                        var _retornoPushWoosh = this.EnvioPushWooshResult(geoValidas, p_mensagem.Mensagem);

                        if (_retornoPushWoosh)
                        {
                            _empresa.QtdePush = _empresa.QtdePush - geoValidas.Count;
                            await this.empresaRepositorio.AtualizarEmpresa(_empresa);
                        }
                    }
                }

                return View();

            }

            ViewBag.Erro = "Nenhuma posição localizada na área informada";

            return View();
        }

        [NonAction]
        private bool EnvioPushWooshResult(NovaMensagemPushViewModel p_mensagem)
        {
            var _retornoPushWoosh = new EnvioPush().EnviarPushNotification(p_mensagem.Mensagem);

            return _retornoPushWoosh;
        }

        [NonAction]
        private bool EnvioPushWooshResult(List<string> p_mensagens, string texto)
        {
            var _retornoPushWoosh = new EnvioPush().EnviarPushNotification(p_mensagens, texto);

            return _retornoPushWoosh;
        }

        [NonAction]
        private bool distance(double lat1, double lon1, double lat2, double lon2, char unit, int raio)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist) <= (double)raio;
        }

        [NonAction]
        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        [NonAction]
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}