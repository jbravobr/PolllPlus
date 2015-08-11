using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class PushProgramado : EntityBase
    {
        public string PushToken { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataEnvio { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioEmail { get; set; }
    }
}
