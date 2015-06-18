using System.Linq;
using System.Data.Entity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using PollPlus.Models;
using PollPlus.Filter;
using PollPlus.Service.Interfaces;
using PollPlus.Domain;
using PagedList;
using System.Collections.Generic;
using System.Text;
using PollPlus.Helpers;
using System.Configuration;

namespace PollPlus.Controllers
{
    [OnlyAuthorizedUser]
    public class AccountController : BaseController
    {
        readonly IUsuarioServiceWEB service;

        public AccountController(IUsuarioServiceWEB Service)
        {
            this.service = Service;
        }

        public AccountController() { }

        [OnlyAuthorizedUser(true), HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [OnlyAuthorizedUser(true), HttpPost]
        public async Task<ActionResult> Login(string usuario, string senha)
        {
            if (String.IsNullOrEmpty(usuario) || String.IsNullOrEmpty(senha))
                return View();

            if (await this.service.LogarUsuario(usuario, senha))
            {
                var _usuario = (await this.service.RetornarTodosUsuarios()).FirstOrDefault(u => u.Email == usuario);
                Session.Add("UsuarioLogado", _usuario);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [OnlyAuthorizedUser(true), HttpGet]
        public ActionResult EsqueciMinhaSenha()
        {
            return View();
        }

        [OnlyAuthorizedUser(true), HttpPost]
        public async Task<ActionResult> EsqueciMinhaSenha(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                var usuario = await this.service.RetornarTodosUsuarios();

                if (usuario.Any(u => u.Email == email))
                {
                    var _corpoMessage = new StringBuilder();

                    _corpoMessage.Append("<p>Você solicitou a alteração por esquecimento da sua senha de acesso ao Sistema de Lojistas do Metrô Rio.</p>");
                    _corpoMessage.AppendLine(String.Format("<p>Seu login é: {0}.</p>", email));
                    _corpoMessage.AppendLine(String.Format("<p><strong>Acesse {0}Usuario/AlteraSenha para alterar a sua senha (OBRIGATÓRIO).</strong></p>", ConfigurationManager.AppSettings["SiteUrl"].ToString()));
                    _corpoMessage.AppendLine("Caso você não entenda do que este e-mail trata-se, favor desconsiderar o mesmo.");

                    var _message = Util.MontaMailMessage(email, _corpoMessage.ToString(), "Cadastro de usuário - Mais");

                    Util.SendMail(_message);

                    return View();
                }
            }

            return View();
        }

        [HttpGet, OnlyAuthorizedUser]
        public async Task<ActionResult> NovoUsuario()
        {
            var categorias = await this.service.RetornarCategoriasDisponniveis();
            ViewBag.CategoriasInteresse = AutoMapper.Mapper.Map<ICollection<CategoriaViewModel>>(categorias);
            return View();
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> NovoUsuario(UsuarioViewModel model)
        {
            var categorias = await this.service.RetornarCategoriasDisponniveis();
            ViewBag.CategoriasInteresse = AutoMapper.Mapper.Map<ICollection<CategoriaViewModel>>(categorias);

            if (!ModelState.IsValid)
                return View(model);
            else
            {
                var user = await this.service.InserirRetornarUsuario(AutoMapper.Mapper.Map<Usuario>(model));

                if (user != null)
                    user.AdicionarCategoria(model.CategoriasInteresse);

                foreach (var uc in user.UsuarioCategoria)
                {
                    await service.InserirUsuarioCategoria(uc);
                }

                return RedirectToAction("ListarUsuarios");
            }
        }

        [HttpGet, OnlyAuthorizedUser]
        public async Task<ActionResult> EditarUsuario(int usuarioId)
        {
            var categorias = await this.service.RetornarCategoriasDisponniveis();
            ViewBag.CategoriasInteresse = AutoMapper.Mapper.Map<ICollection<CategoriaViewModel>>(categorias);

            var usuario = await this.service.RetornarUsuarioPorId(usuarioId);

            if (usuario != null)
                return View(AutoMapper.Mapper.Map<UsuarioViewModel>(usuario));

            return View();
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> EditarUsuario(UsuarioViewModel model)
        {
            var categorias = await this.service.RetornarCategoriasDisponniveis();
            ViewBag.CategoriasInteresse = AutoMapper.Mapper.Map<ICollection<CategoriaViewModel>>(categorias);

            if (!ModelState.IsValid)
                return View(model);
            else if (await this.service.AtualizarUsuario(AutoMapper.Mapper.Map<Usuario>(model)))
                return RedirectToAction("ListarUsuarios");
            else
                return View();
        }

        [HttpGet, OnlyAuthorizedUser]
        public async Task<ActionResult> ListarUsuarios(int? pagina)
        {
            var listaUsuarios = await this.service.RetornarTodosUsuarios();

            return View(listaUsuarios.ToPagedList(pagina ?? 1, 10));
        }
    }
}