using PollPlus.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.Repositorio.EFContext;
using System.Linq.Expressions;

namespace PollPlus.Repositorio
{
    public class SubcategoriaCategoriaRepositorio : BaseRepositorio<SubcategoriaCategoria, PollPlusContext<SubcategoriaCategoria>>, ISubcategoriaCategoriaRepositorio
    {
        public async Task<bool> InserirSubcategoriaCategoria(SubcategoriaCategoria ec)
        {
            base.Inserir(ec);
            return await base.Salvar();
        }

        public async Task<bool> RemoverSubcategoriaCategoria(int id)
        {
            Expression<Func<SubcategoriaCategoria, bool>> porId = (x) => x.Id == id;
            var entity = await base.RetornarPorId(porId);

            base.Deletar(entity);

            return await Task.FromResult<bool>(true);
        }

        public async Task<ICollection<SubcategoriaCategoria>> RetornarSubcategoriaCategoriaPorCategoria(int categoriaId)
        {
            Expression<Func<SubcategoriaCategoria, bool>> porCategoria = (x) => x.CategoriaId == categoriaId;
            return await base.ProcurarPorColecao(porCategoria);
        }

        public async Task<ICollection<SubcategoriaCategoria>> RetornarSubcategoriaCategoriaPorSubcategoria(int subcategoriaId)
        {
            Expression<Func<SubcategoriaCategoria, bool>> porSubCategoria = (x) => x.SubcategoriaId == subcategoriaId;
            return await base.ProcurarPorColecao(porSubCategoria);
        }

        public async Task<ICollection<SubcategoriaCategoria>> RetornarSubcategoriaCategoriaTodos()
        {
            return await base.RetornarTodos();
        }
    }
}
