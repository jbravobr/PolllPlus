using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain.Enumeradores
{
    public enum EnumStatusEnquete
    {
        [Description("Ativa")]
        Ativa = 0,

        [Description("Inativa")]
        Inativa = 1,

        [Description("Publicada")]
        Publicada = 2,

        [Description("Despublicada")]
        Despublicada = 3
    }
}
