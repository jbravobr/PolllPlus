using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class EnqueteVoucher : EntityBase
    {
        public int EnqueteId { get; set; }
        public Enquete Enquete { get; set; }

        public int VoucherId { get; set; }
        public Voucher Voucher { get; set; }
    }
}
