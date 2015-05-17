using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain.Enumeradores
{
    public enum EnumStatusUsuario
    {
        [Description("Ativo")]
        Ativo = 0,

        [Description("Inativo")]
        Inativo = 1
    }
}
