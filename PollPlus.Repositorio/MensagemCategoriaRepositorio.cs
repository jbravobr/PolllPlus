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
    public class MensagemCategoriaRepositorio : BaseRepositorio<MensagemCategoria, PollPlusContext<MensagemCategoria>>, IMensagemCategoriaRepositorio
    {
        public async Task<bool> InserirMensagemCategoria(MensagemCategoria ec)
        {
            base.Inserir(ec);
            return await base.Salvar();
        }

        public async Task<bool> RemoverMensagemCategoria(int id)
        {
            Expression<Func<MensagemCategoria, bool>> porId = (x) => x.Id == id;
            var entity = await base.RetornarPorId(porId);

            base.Deletar(entity);

            return await Task.FromResult<bool>(true);
        }

        public async Task<ICollection<MensagemCategoria>> RetornarMensagemCategoriaPorMensagem(int mensagemId)
        {
            Expression<Func<MensagemCategoria, bool>> porMensagemId = (x) => x.MensagemId == mensagemId;
            return await base.ProcurarPorColecao(porMensagemId);
        }

        public async Task<ICollection<MensagemCategoria>> RetornarMensagemCategoriaPorCategoria(int categoriaId)
        {
            Expression<Func<MensagemCategoria, bool>> porCategoria = (x) => x.CategoriaId == categoriaId;
            return await base.ProcurarPorColecao(porCategoria);
        }

        public async Task<ICollection<MensagemCategoria>> RetornarMensagemCategoriaTodos()
        {
            return await base.RetornarTodos();
        }
    }
}
