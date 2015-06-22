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
        public Guid Identificador { get; set; }
        public EnumStatusVoucher Status { get; set; }
    }
}
