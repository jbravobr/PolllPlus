using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Resposta : EntityBase
    {
        public string TextoResposta { get; protected set; }
        public DateTime? DataResposta { get; protected set; }

        public virtual Pergunta Pergunta { get; protected set; }
    }
}
