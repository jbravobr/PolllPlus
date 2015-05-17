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
        public Guid Identificador { get; protected set; }
        public EnumStatusVoucher Status { get; protected set; }

        public virtual ICollection<Enquete> Enquetes { get; protected set; }
    }
}
