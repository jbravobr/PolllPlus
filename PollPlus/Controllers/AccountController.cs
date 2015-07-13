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
using System.Web;

namespace PollPlus.Controllers
{
    [OnlyAuthorizedUser]
    public class AccountController : BaseController
    {
        readonly IUsuarioServiceWEB service;

        readonly IEmpresaServiceWEB serviceEmpresas;

        readonly IEnqueteServiceWEB serviceEnquete;

        public AccountController(IUsuarioServiceWEB Service, IEmpresaServiceWEB ServiceEmpresas, IEnqueteServiceWEB ServiceEnquete)
        {
            this.service = Service;
            this.serviceEmpresas = ServiceEmpresas;
            this.serviceEnquete = ServiceEnquete;
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

            if (true) //await this.service.LogarUsuario(usuario, senha))
            {
                var _usuario = await this.service.RetornarUsuarioPorId(1);
                //var _usuario = await this.service.RetornarTodosUsuarios();
                //Session.Add("UsuarioLogado", _usuario.FirstOrDefault(u => u.Email == usuario));
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
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, null));

            var empresas = await this.serviceEmpresas.RetornarTodasEmpresas();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, null));

            return View();
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> NovoUsuario(UsuarioViewModel model)
        {
            var categorias = await this.service.RetornarCategoriasDisponniveis();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, null));

            var empresas = await this.serviceEmpresas.RetornarTodasEmpresas();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, null));

            if (!ModelState.IsValid)
            {
                ViewBag.CategoriasInteresse = PreparaParaListaDeCategorias(categorias, model.CategoriasInteresse);
                ViewBag.Empresas = PreparaParaListaDeEmpresas(empresas, model.EmpresaId);
                return View(model);
            }
            else
            {
                if (UsuarioLogado.UsuarioAutenticado().Perfil == Domain.Enumeradores.EnumPerfil.AdministradorEmpresa)
                {
                    model.Perfil = Domain.Enumeradores.EnumPerfil.AdministradorEmpresa;
                    model.EmpresaId = (int)UsuarioLogado.UsuarioAutenticado().EmpresaId;
                }

                var user = await this.service.InserirRetornarUsuario(AutoMapper.Mapper.Map<Usuario>(model));

                if (user != null)
                    user.AdicionarCategoria(model.CategoriasInteresse);

                foreach (var uc in user.UsuarioCategoria)
                {
                    await service.InserirUsuarioCategoria(uc);
                }

                EnviarEmailConfirmacaoCadastro(user);

                return RedirectToAction("ListarUsuarios");
            }
        }

        [NonAction]
        private bool EnviarEmailConfirmacaoCadastro(Usuario usuario)
        {
            var _corpoMessage = new StringBuilder();

            _corpoMessage.Append("<p>Está é a confirmação da criação do seu usuário para acesso ao Sistema de Mais.</p>");
            _corpoMessage.AppendLine(String.Format("<p>Seu login é: {0}.</p>", usuario.Email));
            _corpoMessage.AppendLine("Caso você não entenda do que este e-mail trata-se, favor desconsiderar o mesmo.");

            var _message = Util.MontaMailMessage(usuario.Email, _corpoMessage.ToString(), "Cadastro de usuário - Sistema Mais");

            return Util.SendMail(_message);
        }

        [HttpGet, OnlyAuthorizedUser]
        public async Task<ActionResult> EditarUsuario(int usuarioId)
        {
            var usuario = await this.service.RetornarUsuarioPorId(usuarioId);

            var categorias = await this.service.RetornarCategoriasDisponniveis();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, usuario.UsuarioCategoria.Select(c => c.CategoriaId).ToList()));

            var empresas = await this.serviceEmpresas.RetornarTodasEmpresas();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, usuario.EmpresaId));

            if (usuario != null)
                return View(AutoMapper.Mapper.Map<UsuarioViewModel>(usuario));

            return View();
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> EditarUsuario(UsuarioViewModel model)
        {
            var categorias = await this.service.RetornarCategoriasDisponniveis();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, model.UsuarioCategoria.Select(c => c.CategoriaId).ToList()));

            var empresas = await this.serviceEmpresas.RetornarTodasEmpresas();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, model.EmpresaId));

            if (!ModelState.IsValid)
            {
                ViewBag.Empresas = PreparaParaListaDeEmpresas(empresas, model.EmpresaId);
                ViewBag.CategoriasInteresse = PreparaParaListaDeCategorias(categorias, model.CategoriasInteresse);
                return View(model);
            }
            else if (await this.service.AtualizarUsuario(AutoMapper.Mapper.Map<Usuario>(model)))
                return RedirectToAction("ListarUsuarios");
            else
                return View();
        }

        [HttpGet, OnlyAuthorizedUser]
        public async Task<ActionResult> ListarUsuarios(int? pagina)
        {
            var listaUsuarios = await this.service.RetornarTodosUsuarios();

            ViewBag.ContUsuariosTotal = listaUsuarios.Count;
            ViewBag.ContUsuariosAtivosTotal = listaUsuarios.Where(u => u.Status == Domain.Enumeradores.EnumStatusUsuario.Ativo).Count();

            return View(listaUsuarios.Where(u => u.Status == Domain.Enumeradores.EnumStatusUsuario.Ativo).ToPagedList(pagina ?? 1, 10));
        }

        [HttpGet, OnlyAuthorizedUser]
        public ActionResult ImportarEmail()
        {
            return View();
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> ImportarEmail(HttpPostedFileBase file)
        {
            if (file.ContentLength <= 0)
                return View(0);

            try
            {
                var usuarios = (ICollection<Usuario>)Util.ImportarCSV(EnumTipoImportacao.Email, file);

                foreach (var item in usuarios)
                {
                    await this.service.InserirUsuario(item);
                }

                return View(1);
            }
            catch (Exception ex)
            {
                return View(0);
            }
        }

        [HttpGet, OnlyAuthorizedUser]
        public async Task<ActionResult> RemoverUsuario(int usuarioId)
        {
            var user = await this.service.RetornarUsuarioPorId(usuarioId);
            user.ConfiguraStatus(Domain.Enumeradores.EnumStatusUsuario.Inativo);
            await this.service.AtualizarUsuario(user);

            return RedirectToAction("ListarUsuarios");
        }

        [NonAction]
        private static IEnumerable<SelectListItem> PreparaParaListaDeEmpresas(ICollection<Empresa> empresas, int? empresaSelecionada = null)
        {
            foreach (var empresa in empresas)
            {
                if (empresaSelecionada != null)
                {
                    yield return new SelectListItem
                    {
                        Text = empresa.Nome,
                        Value = empresa.Id.ToString(),
                        Selected = empresa.Id == empresaSelecionada
                    };
                }

                yield return new SelectListItem
                {
                    Text = empresa.Nome,
                    Value = empresa.Id.ToString()
                };
            }
        }

        [NonAction]
        private static IEnumerable<SelectListItem> PreparaParaListaDeCategorias(ICollection<Categoria> categorias, List<int> categoriaSelecionada = null)
        {
            foreach (var categoria in categorias)
            {
                if (categoriaSelecionada != null)
                {
                    yield return new SelectListItem
                    {
                        Text = categoria.Nome,
                        Value = categoria.Id.ToString(),
                        Selected = categoriaSelecionada.Contains((int)categoria.Id)
                    };
                }

                yield return new SelectListItem
                {
                    Text = categoria.Nome,
                    Value = categoria.Id.ToString()
                };
            }
        }
    }
}