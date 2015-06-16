using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class PerguntaResposta : EntityBase
    {
        public int PerguntaId { get; set; }
        public Pergunta Pergunta { get; set; }

        public int RespostaId { get; set; }
        public Resposta Resposta { get; set; }

        public bool Respondida { get; set; }
    }
}
