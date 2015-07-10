using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class UsoPushPorEmpresa : EntityBase
    {
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        public int QtdePushDisponiveis { get; set; }
    }
}
