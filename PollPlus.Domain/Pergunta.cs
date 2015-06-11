using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Pergunta : EntityBase
    {
        public string TextoPergunta { get; protected set; }

        public virtual ICollection<Resposta> Respostas { get; protected set; }
    }
}
