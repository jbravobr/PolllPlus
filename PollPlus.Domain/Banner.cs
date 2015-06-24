using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Banner : EntityBase
    {
        public string FileName { get; set; }

        public int? EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        public int? EnqueteId { get; set; }
        public virtual Enquete Enquete { get; set; }
    }
}
