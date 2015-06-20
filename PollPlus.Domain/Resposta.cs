using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Resposta : EntityBase
    {
        public string TextoResposta { get; set; }

        public int PerguntaId { get; set; }
    }
}
