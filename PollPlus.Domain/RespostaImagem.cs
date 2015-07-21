using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class RespostaImagem : EntityBase
    {
        public int RespostaId { get; set; }
        public virtual Resposta Resposta { get; set; }

        public string Imagem { get; set; }
    }
}
