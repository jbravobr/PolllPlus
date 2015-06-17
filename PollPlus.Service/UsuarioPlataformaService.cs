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
    public class UsuarioPlataformaiaRepositorio : BaseRepositorio<UsuarioPlataforma, PollPlusContext<UsuarioPlataforma>>, IUsuarioPlataformaRepositorio
    {
        public async Task<bool> InserirUsuarioPlataforma(UsuarioPlataforma ec)
        {
            base.Inserir(ec);
            return await base.Salvar();
        }

        public async Task<bool> RemoverUsuarioPlataforma(int id)
        {
            Expression<Func<UsuarioPlataforma, bool>> porId = (x) => x.Id == id;
            var entity = await base.RetornarPorId(porId);

            base.Deletar(entity);

            return await Task.FromResult<bool>(true);
        }

        public async Task<ICollection<UsuarioPlataforma>> RetornarUsuarioPlataformaPorUsuario(int usuarioId)
        {
            Expression<Func<UsuarioPlataforma, bool>> porUsuario = (x) => x.UsuarioId == usuarioId;
            return await base.ProcurarPorColecao(porUsuario);
        }

        public async Task<ICollection<UsuarioPlataforma>> RetornarUsuarioPlataformaPorPlataforma(int plataformaId)
        {
            Expression<Func<UsuarioPlataforma, bool>> porPlataforma = (x) => x.PlataformaId == plataformaId;
            return await base.ProcurarPorColecao(porPlataforma);
        }

        public async Task<ICollection<UsuarioPlataforma>> RetornarUsuarioPlataformaTodos()
        {
            return await base.RetornarTodos();
        }
    }
}
