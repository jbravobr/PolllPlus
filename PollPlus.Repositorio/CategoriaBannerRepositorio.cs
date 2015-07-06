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
    public class CategoriaBannerRepositorio : BaseRepositorio<CategoriaBanner, PollPlusContext<CategoriaBanner>>
    {
        public async Task<bool> InserirCB(CategoriaBanner ec)
        {
            base.Inserir(ec);
            return await base.Salvar();
        }

        public async Task<bool> RemoverCB(int id)
        {
            Expression<Func<CategoriaBanner, bool>> porId = (x) => x.Id == id;
            var entity = await base.RetornarPorId(porId);

            base.Deletar(entity);

            return await Task.FromResult<bool>(true);
        }

        public async Task<ICollection<CategoriaBanner>> RetornarCategoriaBannerPorCategoria(int categoriaId)
        {
            Expression<Func<CategoriaBanner, bool>> porCategoriaId = (x) => x.CategoriaId == categoriaId;
            return await base.ProcurarPorColecao(porCategoriaId);
        }

        public async Task<ICollection<CategoriaBanner>> RetornarCategoriaBannerPorBanner(int bannerId)
        {
            Expression<Func<CategoriaBanner, bool>> porBannerId = (x) => x.BannerId == bannerId;
            return await base.ProcurarPorColecao(porBannerId);
        }

        public async Task<ICollection<CategoriaBanner>> RetornarCategoriaBannerTodos()
        {
            return await base.RetornarTodos();
        }
    }
}
