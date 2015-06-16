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
    public class EnqueteVoucherRepositorio : BaseRepositorio<EnqueteVoucher, PollPlusContext<EnqueteVoucher>>, IEnqueteVoucherRepositorio
    {
        public async Task<bool> InserirEnqueteVoucher(EnqueteVoucher ec)
        {
            base.Inserir(ec);
            return await base.Salvar();
        }

        public async Task<bool> RemoverEnqueteVoucher(int id)
        {
            Expression<Func<EnqueteVoucher, bool>> porId = (x) => x.Id == id;
            var entity = await base.RetornarPorId(porId);

            base.Deletar(entity);

            return await Task.FromResult<bool>(true);
        }

        public async Task<ICollection<EnqueteVoucher>> RetornarEnqueteVoucherPorEnquete(int enqueteId)
        {
            Expression<Func<EnqueteVoucher, bool>> porEnqueteId = (x) => x.EnqueteId == enqueteId;
            return await base.ProcurarPorColecao(porEnqueteId);
        }

        public async Task<ICollection<EnqueteVoucher>> RetornarEnqueteVoucherPorVoucher(int voucherId)
        {
            Expression<Func<EnqueteVoucher, bool>> porEnquete = (x) => x.VoucherId == voucherId;
            return await base.ProcurarPorColecao(porEnquete);
        }

        public async Task<ICollection<EnqueteVoucher>> RetornarEnqueteVoucherTodos()
        {
            return await base.RetornarTodos();
        }
    }
}
