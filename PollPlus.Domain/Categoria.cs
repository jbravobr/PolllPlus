using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Categoria : EntityBase
    {
        public string Nome { get; set; }
        public EnumStatusCategoria Status { get; set; }

        public virtual ICollection<SubcategoriaCategoria> SubcategoriaCategoria { get; set; }
    }
}
