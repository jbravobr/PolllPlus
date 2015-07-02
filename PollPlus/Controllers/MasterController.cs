using PollPlus.Domain;
using PollPlus.Models;
using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PollPlus.Controllers
{
    public class MasterController : BaseController
    {
        readonly IUsuarioServiceWEB service;

        readonly IEmpresaServiceWEB serviceEmpresas;

        readonly IEnqueteServiceWEB serviceEnquete;         

        public MasterController(IUsuarioServiceWEB Service, IEmpresaServiceWEB ServiceEmpresas, IEnqueteServiceWEB ServiceEnquete)
        {
            this.service = Service;
            this.serviceEmpresas = ServiceEmpresas;
            this.serviceEnquete = ServiceEnquete;
        }


        [HttpGet]
        public async Task<ActionResult> MasterCriaUsuario()
        {
            var categorias = await this.service.RetornarCategoriasDisponniveis();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, null));

            var empresas = await this.serviceEmpresas.RetornarTodasEmpresasMaster();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, null));

            return View();
        }

       

        [HttpPost]
        public async Task<ActionResult> MasterCriaUsuario(UsuarioViewModel model)
        {
            var categorias = await this.service.RetornarCategoriasDisponniveis();
            ViewData.Add("CategoriasForSelectList", PreparaParaListaDeCategorias(categorias, null));

            var empresas = await this.serviceEmpresas.RetornarTodasEmpresasMaster();
            ViewData.Add("EmpresasForSelectList", PreparaParaListaDeEmpresas(empresas, null));

            if (!ModelState.IsValid)
            {
                ViewBag.CategoriasInteresse = PreparaParaListaDeCategorias(categorias, model.CategoriasInteresse);
                ViewBag.Empresas = PreparaParaListaDeEmpresas(empresas, model.EmpresaId);
                return View(model);
            }
            else
            {
                var user = await this.service.InserirRetornarUsuario(AutoMapper.Mapper.Map<Usuario>(model));

                if (user != null)
                    user.AdicionarCategoria(model.CategoriasInteresse);

                foreach (var uc in user.UsuarioCategoria)
                {
                    await service.InserirUsuarioCategoria(uc);
                }

                return RedirectToAction("Login", "Account");
            }
        }


        [NonAction]
        private IEnumerable<SelectListItem> PreparaParaListaDeCategorias(ICollection<Categoria> categorias, List<int> categoriaSelecionada = null)
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

        [NonAction]
        private IEnumerable<SelectListItem> PreparaParaListaDeEmpresas(ICollection<Empresa> empresas, int? empresaSelecionada = null)
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
    }
}