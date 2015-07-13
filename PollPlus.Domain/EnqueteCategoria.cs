using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class EnqueteCategoria : EntityBase
    {
        public int EnqueteId { get; set; }
        public virtual Enquete Enquete { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
