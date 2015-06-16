using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Plataforma : EntityBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int AppID { get; set; }
    }
}
