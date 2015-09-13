using PollPlus.Filter;
using PollPlus.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PollPlus.Helpers;

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

        [HttpGet, OnlyAuthorizedUser]
        public async Task<ActionResult> EditarCategoria(int categoriaId)
        {
            var categoria = await this.repo.RetornarCategoriaPorId(categoriaId);

            return View(categoria);
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> EditarCategoria(Domain.Categoria model, HttpPostedFileBase file)
        {
            if (model != null)
            {
                if (file.ContentLength > 0)
                    if (Util.SalvarImagem(file))
                        model.Imagem = file.FileName;

                        if (await this.repo.AtualizarCategoria(model))
                            return RedirectToAction("ListarCategorias");
            }

            return View();
        }

        [HttpPost, OnlyAuthorizedUser]
        public async Task<ActionResult> NovaCategoria(string categoria, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
                Util.SalvarImagem(file);

            await this.repo.InserirCategoria(new Domain.Categoria { Nome = categoria, Status = Domain.Enumeradores.EnumStatusCategoria.Habilitada, Imagem = file.ContentLength > 0 ? file.FileName : string.Empty });

            return RedirectToAction("ListarCategorias");
        }

        [HttpGet, OnlyAuthorizedUser]
        public async Task<ActionResult> ListarCategorias(int? pagina)
        {
            var categorias = await this.repo.RetornarTodasCategorias();

            return View(categorias.OrderByDescending(x => x.DataCriacao).ToPagedList(pagina ?? 1, 10));
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