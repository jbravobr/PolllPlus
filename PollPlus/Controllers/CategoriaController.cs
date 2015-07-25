using PollPlus.Filter;
using PollPlus.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace PollPlus.Controllers
{
    public class CategoriaController : BaseController
    {
        private CategoriaRepositorio repo = new CategoriaRepositorio();
        readonly EnqueteCategoriaRepositorio repoEnqueteCategoria = new EnqueteCategoriaRepositorio();

        [HttpGet, OnlyAuthorizedUser]
        public ActionResult NovaCategoria()
        {
            return View();
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> NovaCategoria(string categoria)
        {
            await this.repo.InserirCategoria(new Domain.Categoria { Nome = categoria, Status = Domain.Enumeradores.EnumStatusCategoria.Habilitada });

            return RedirectToAction("ListarCategorias");
        }

        [HttpGet, OnlyAuthorizedUser]
        public async Task<ActionResult> ListarCategorias(int? pagina)
        {
            var categorias = await this.repo.RetornarTodasCategorias();

            return View(categorias.OrderByDescending(x=>x.DataCriacao).ToPagedList(pagina ?? 1, 10));
        }

        [HttpGet, OnlyAuthorizedUser]
        public async Task<ActionResult> RemoverCategoria(int categoriaId)
        {
            var existeAssociacao = (await this.repoEnqueteCategoria.RetornarTodos()).Any(x => x.CategoriaId == categoriaId);

            if (!existeAssociacao)
            {
                await this.repo.DeletarCategoria(await this.repo.RetornarCategoriaPorId(categoriaId));
                return RedirectToAction("ListarCategorias");
            }

            ViewBag.Mensagem = "Categoria já possui associações, impossível excluir!";

            return View();
        }
    }
}