using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Voucher : EntityBase
    {
        public Guid Identificador { get; set; }
        public EnumStatusVoucher Status { get; set; }
    }
}
