using PollPlus.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using System.Linq.Expressions;

namespace PollPlus.Repositorio
{
    public class EnqueteVoucherService : IEnqueteVoucherService
    {
        readonly IEnqueteVoucherRepositorio _repositorio;

        public EnqueteVoucherService(IEnqueteVoucherRepositorio repo)
        {
            this._repositorio = repo;
        }

        public async Task<bool> InserirEnqueteVoucher(EnqueteVoucher ec)
        {
            return await this._repositorio.InserirEnqueteVoucher(ec);
        }

        public async Task<bool> RemoverEnqueteVoucher(int id)
        {
            return await this._repositorio.RemoverEnqueteVoucher(id);
        }

        public async Task<ICollection<EnqueteVoucher>> RetornarEnqueteVoucherPorEnquete(int enqueteId)
        {
            return await this._repositorio.RetornarEnqueteVoucherPorEnquete(enqueteId);
        }

        public async Task<ICollection<EnqueteVoucher>> RetornarEnqueteVoucherPorVoucher(int voucherId)
        {
            return await this._repositorio.RetornarEnqueteVoucherPorVoucher(voucherId);
        }

        public async Task<ICollection<EnqueteVoucher>> RetornarEnqueteVoucherTodos()
        {
            return await this._repositorio.RetornarEnqueteVoucherTodos();
        }
    }
}
