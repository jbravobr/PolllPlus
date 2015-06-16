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
    public class EnqueteCategoriaRepositorio : BaseRepositorio<EnqueteCategoria, PollPlusContext<EnqueteCategoria>>, IEnqueteCategoriaRepositorio
    {
        public async Task<bool> InserirEnqueteCategoria(EnqueteCategoria ec)
        {
            base.Inserir(ec);
            return await base.Salvar();
        }

        public async Task<bool> RemoverEnqueteCategoria(int id)
        {
            Expression<Func<EnqueteCategoria, bool>> porId = (x) => x.Id == id;
            var entity = await base.RetornarPorId(porId);

            base.Deletar(entity);

            return await Task.FromResult<bool>(true);
        }

        public async Task<ICollection<EnqueteCategoria>> RetornarEnqueteCategoriaCategoria(int categoriaId)
        {
            Expression<Func<EnqueteCategoria, bool>> porCategoriaId = (x) => x.CategoriaId == categoriaId;
            return await base.ProcurarPorColecao(porCategoriaId);
        }

        public async Task<ICollection<EnqueteCategoria>> RetornarEnqueteCategoriaEnquete(int enqueteId)
        {
            Expression<Func<EnqueteCategoria, bool>> porEnquete = (x) => x.EnqueteId == enqueteId;
            return await base.ProcurarPorColecao(porEnquete);
        }

        public async Task<ICollection<EnqueteCategoria>> RetornarEnqueteCategoriaTodos()
        {
            return await base.RetornarTodos();
        }
    }
}
