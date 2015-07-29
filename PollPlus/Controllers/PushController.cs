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
        [HttpGet, OnlyAuthorizedUser]
        public ActionResult NovoPush()
        {
            return View();
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> NovoPush(NovaMensagemPushViewModel p_mensagem)
        {
            if (!ModelState.IsValid)
                return View(p_mensagem);

            var qtdePush = UsuarioLogado.UsuarioAutenticado().Empresa.QtdePush;

            var _retornoPushWoosh = EnvioPushWooshResult(p_mensagem);

            ViewBag.Mensagens = new List<String>();
            if (!_retornoPushWoosh)
                ViewBag.Mensagens.Add("<span style=\"color:red;font-weight:bold:font-size:18px\">Mensagem Push não foi disparada.<\\span>");
            else
            {
                var repo = new UsoPushPorEmpresaRepositorio();
                var dado = (await repo.RetornarTodos()).First(e => e.EmpresaId == UsuarioLogado.UsuarioAutenticado().EmpresaId);
                dado.QtdePushDisponiveis = dado.QtdePushDisponiveis - 1;
                await repo.AtualizarUsoPushPorEmpresa(dado);
                ViewBag.Mensagens.Add("<span style=\"color:green;font-weight:bold:font-size:18px\">Mensagem Push enviada com sucesso.<\\span>");
            }

            return View();
        }

        [NonAction]
        private bool EnvioPushWooshResult(NovaMensagemPushViewModel p_mensagem)
        {
            var _retornoPushWoosh = new EnvioPush().EnviarPushNotification(p_mensagem.Mensagem);

            return _retornoPushWoosh;
        }
    }
}