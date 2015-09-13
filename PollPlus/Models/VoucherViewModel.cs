using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Models
{
    public class VoucherViewModel
    {
        public int Id { get; set; }
        public int QtdeVoucherParaEmitir { get; set; }
        public EnumStatusVoucher Status { get; set; }
        public string Descricao { get; set; }
        public DateTime DataValidade { get; set; }
        public int EmpresaId { get; set; }
        public int EnqueteId { get; set; }
        public string ImagemEmail { get; set; }

        public List<string> NroVoucher { get; set; }
    }
}
