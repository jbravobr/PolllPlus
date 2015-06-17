using PollPlus.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using System.Linq.Expressions;

namespace PollPlus.Repositorio
{
    public class SubcategoriaCategoriaService : ISubcategoriaCategoriaService
    {
        readonly ISubcategoriaCategoriaRepositorio _repositorio;

        public SubcategoriaCategoriaService(ISubcategoriaCategoriaRepositorio repo)
        {
            this._repositorio = repo;
        }

        public async Task<bool> InserirSubcategoriaCategoria(SubcategoriaCategoria ec)
        {
            return await this._repositorio.InserirSubcategoriaCategoria(ec);
        }

        public async Task<bool> RemoverSubcategoriaCategoria(int id)
        {
            return await this._repositorio.RemoverSubcategoriaCategoria(id);
        }

        public async Task<ICollection<SubcategoriaCategoria>> RetornarSubcategoriaCategoriaPorCategoria(int categoriaId)
        {
            return await this._repositorio.RetornarSubcategoriaCategoriaPorCategoria(categoriaId);
        }

        public async Task<ICollection<SubcategoriaCategoria>> RetornarSubcategoriaCategoriaPorSubcategoria(int subcategoriaId)
        {
            return await this._repositorio.RetornarSubcategoriaCategoriaPorSubcategoria(subcategoriaId);

        }

        public async Task<ICollection<SubcategoriaCategoria>> RetornarSubcategoriaCategoriaTodos()
        {
            return await this._repositorio.RetornarSubcategoriaCategoriaTodos();
        }
    }
}
