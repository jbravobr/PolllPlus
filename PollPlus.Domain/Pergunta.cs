using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Pergunta : EntityBase
    {
        public string TextoPergunta { get; set; }

        public virtual ICollection<Resposta> Resposta { get; set; }
    }
}
