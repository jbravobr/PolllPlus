using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Empresa : EntityBase
    {
        public string Nome { get; protected set; }
        public string Logo { get; protected set; }

        public virtual Documento Documento { get; protected set; }
        public virtual ICollection<Categoria> Categorias { get; protected set; }
    }
}
