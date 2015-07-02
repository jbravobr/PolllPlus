using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
namespace PollPlus.IService
{
    public interface IVoucherService
    {
        Task<bool> InserirVoucher(Voucher e);
        Task<bool> AtualizarVoucher(Voucher e);
        Task<bool> DeletarVoucher(Voucher e);
        Task<Voucher> RetornarVoucherPorId(int id);
        Task<ICollection<Voucher>> RetornarTodosVouchers();
        Task<Voucher> InserirRetornarVoucher(Voucher e);
    }
}
