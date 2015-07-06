using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class EmpresaBanner : EntityBase
    {
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        public int BannerId { get; set; }
        public virtual Banner Banner { get; set; }
    }
}
