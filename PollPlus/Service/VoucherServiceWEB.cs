using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IService;

namespace PollPlus.Service
{
    public class VoucherServiceWEB : IVoucherServiceWEB
    {
        readonly IVoucherService service;

        public VoucherServiceWEB(IVoucherService _service)
        {
            this.service = _service;
        }

        public async Task<bool> AtualizarVoucher(Voucher e)
        {
            return await this.service.AtualizarVoucher(e);
        }

        public async Task<bool> DeletarVoucher(Voucher e)
        {
            return await this.service.DeletarVoucher(e);
        }

        public async Task<bool> InserirVoucher(Voucher e)
        {
            return await this.service.InserirVoucher(e);
        }

        public async Task<ICollection<Voucher>> RetornarTodosVouchers()
        {
            return await this.service.RetornarTodosVouchers();
        }

        public async Task<Voucher> RetornarVoucherPorId(int id)
        {
            return await this.service.RetornarVoucherPorId(id);
        }
    }
}
