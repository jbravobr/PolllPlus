﻿using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Service.Interfaces
{
    public interface IVoucherServiceWEB
    {
        Task<bool> InserirVoucher(Voucher e);
        Task<Voucher> InserirRetornarVoucher(Voucher e);
        Task<bool> AtualizarVoucher(Voucher e);
        Task<bool> DeletarVoucher(Voucher e);
        Task<Voucher> RetornarVoucherPorId(int id);
        Task<ICollection<Voucher>> RetornarTodosVouchers();

        Task<bool> AssociaVoucherEnquete(int enqueteId, int voucherId);
    }
}
