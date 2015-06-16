using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IEnqueteVoucherRepositorio
    {
        Task<bool> InserirEnqueteVoucher(EnqueteVoucher ev);
        Task<bool> RemoverEnqueteVoucher(int id);
        Task<ICollection<EnqueteVoucher>> RetornarEnqueteVoucherPorEnquete(int enqueteId);
        Task<ICollection<EnqueteVoucher>> RetornarEnqueteVoucherPorVoucher(int voucherId);
        Task<ICollection<EnqueteVoucher>> RetornarEnqueteVoucherTodos();
    }
}
