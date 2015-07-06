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
    public class EmpresaBannerRepositorio : BaseRepositorio<EmpresaBanner, PollPlusContext<CategoriaBanner>>
    {
        public async Task<bool> InserirCB(EmpresaBanner ec)
        {
            base.Inserir(ec);
            return await base.Salvar();
        }

        public async Task<bool> RemoverCB(int id)
        {
            Expression<Func<EmpresaBanner, bool>> porId = (x) => x.Id == id;
            var entity = await base.RetornarPorId(porId);

            base.Deletar(entity);

            return await Task.FromResult<bool>(true);
        }

        public async Task<ICollection<EmpresaBanner>> RetornarEmpresaBannerPorEmpresa(int empresaId)
        {
            Expression<Func<EmpresaBanner, bool>> porEmpresaId = (x) => x.EmpresaId == empresaId;
            return await base.ProcurarPorColecao(porEmpresaId);
        }

        public async Task<ICollection<EmpresaBanner>> RetornarEmpresaBannerPorBanner(int bannerId)
        {
            Expression<Func<EmpresaBanner, bool>> porBannerId = (x) => x.BannerId == bannerId;
            return await base.ProcurarPorColecao(porBannerId);
        }

        public async Task<ICollection<EmpresaBanner>> RetornarEmpresaBannerTodos()
        {
            return await base.RetornarTodos();
        }
    }
}
