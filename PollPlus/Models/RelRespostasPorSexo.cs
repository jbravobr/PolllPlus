using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PollPlus.Models
{
    public class RelRespostasPorSexo
    {
        public int Id { get; set; }
        public string TextoResposta { get; set; }
        public int PorHomens { get; set; }
        public int PorMulheres { get; set; }
    }
}