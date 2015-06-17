using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Models
{
    public class EnqueteViewModel
    {
        public int Id { get; set; }

        public PerguntaViewModel Pergunta { get; set; }
    }
}
