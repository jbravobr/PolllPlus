using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using PollPlus.Models;
using PollPlus.Filter;
using PollPlus.Service.Interfaces;
using PollPlus.Domain;
using PagedList;
using System.Collections.Generic;

namespace PollPlus.Controllers
{
    //[OnlyAuthorizedUser]
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

        [HttpGet, OnlyAuthorizedUser(true)]
        public async Task<ActionResult> NovoUsuario()
        {
            var categorias = await this.service.RetornarCategoriasDisponniveis();
            ViewBag.CategoriasInteresse = AutoMapper.Mapper.Map<ICollection<CategoriaViewModel>>(categorias);
            return View();
        }

        [HttpPost]
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

        [HttpGet]
        public async Task<ActionResult> ListarUsuarios(int? pagina)
        {
            var listaUsuarios = await this.service.RetornarTodosUsuarios();

            return View(listaUsuarios.ToPagedList(pagina ?? 1, 10));
        }
    }
}