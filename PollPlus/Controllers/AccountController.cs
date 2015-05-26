using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PollPlus.Models;
using PollPlus.Filter;
using PollPlus.Service.Interfaces;
using PollPlus.Domain;
using PagedList;
using PollPlus.Filters;
using PollPlus.Domain.Enumeradores;

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
        public async Task<ActionResult> Login()
        {
            return View();
        }

        [OnlyAuthorizedUser(true), HttpPost]
        public async Task<ActionResult> Login(UsuarioViewModel model)
        {
            return View();
        }

        [HttpGet]
        [CustomActionFilter(PerfilAutorizado = new[] { EnumPerfil.AdministradorEmpresa, EnumPerfil.AdministradorMaster })]
        public async Task<ActionResult> NovoUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> NovoUsuario(UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            else if (await this.service.InserirUsuario(AutoMapper.Mapper.Map<Usuario>(model)))
                return RedirectToAction("ListarUsuarios");
            else
                return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> ListarUsuarios(int? pagina)
        {
            var listaUsuarios = await this.service.RetornarTodosUsuarios();

            return View(listaUsuarios.ToPagedList(pagina ?? 1, 10));
        }
    }
}