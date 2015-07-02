using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Voucher : EntityBase
    {
        public string Identificador { get; set; }
        public EnumStatusVoucher Status { get; set; }
        public DateTime DataValidade { get; set; }
        public bool Usado { get; set; }
        public string Descricao { get; set; }
    }
}
