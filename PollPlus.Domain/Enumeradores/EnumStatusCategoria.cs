using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain.Enumeradores
{
    public enum EnumStatusCategoria
    {
        [Description("Habilitada")]
        Habilitada = 0,

        [Description("Desabilitada")]
        Desabilitada = 1
    }
}
