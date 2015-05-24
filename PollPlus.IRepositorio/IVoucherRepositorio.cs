using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IVoucherRepositorio
    {
        Task<bool> InserirVoucher(Voucher e);
        Task<bool> AtualizarVoucher(Voucher e);
        Task<bool> DeletarVoucher(Voucher e);
        Task<Voucher> RetornarVoucherPorId(int id);
        Task<ICollection<Voucher>> RetornarTodosVouchers();
    }
}
