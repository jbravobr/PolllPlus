using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Empresa : EntityBase
    {
        public string Nome { get; set; }
        public string Logo { get; set; }
        public int QtdePush { get; set; }

        public int DocumentoId { get; set; }
        public virtual Documento Documento { get; set; }

        public virtual ICollection<Mensagem> Mensagem { get; set; }
    }
}
