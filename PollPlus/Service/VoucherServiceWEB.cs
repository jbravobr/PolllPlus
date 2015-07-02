using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IService;
using PollPlus.Domain.Enumeradores;
using PollPlus.Helpers;

namespace PollPlus.Service
{
    public class VoucherServiceWEB : IVoucherServiceWEB
    {
        readonly IVoucherService service;
        readonly IEnqueteVoucherService serviceEnqueteVoucher;

        public VoucherServiceWEB(IVoucherService _service, IEnqueteVoucherService _serviceEnqueteVoucher)
        {
            this.service = _service;
            this.serviceEnqueteVoucher = _serviceEnqueteVoucher;
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
            var _voucher = new List<Voucher>();
            if (UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorEmpresa)
                _voucher = (await this.service.RetornarTodosVouchers()).Where(u => u.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId).ToList();
            else
                _voucher = (await this.service.RetornarTodosVouchers()).ToList();
            return _voucher;
        }

        public async Task<Voucher> RetornarVoucherPorId(int id)
        {
            return await this.service.RetornarVoucherPorId(id);
        }

        public async Task<bool> AssociaVoucherEnquete(int enqueteId, int voucherId)
        {
            var entity = new EnqueteVoucher { EnqueteId = enqueteId, VoucherId = voucherId };

            return await this.serviceEnqueteVoucher.InserirEnqueteVoucher(entity);
        }

        public async Task<Voucher> InserirRetornarVoucher(Voucher e)
        {
            return await this.service.InserirRetornarVoucher(e);
        }
    }
}
