using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class AcaoEnvio : EntityBase
    {
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        public string Mensagem { get; set; }
        public DateTime DataValidade { get; set; }
        public EnumAreaAcesso TipoAcao { get; set; }
        public bool Status { get; set; }
    }
}
