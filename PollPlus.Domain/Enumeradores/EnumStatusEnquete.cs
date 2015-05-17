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
        Inativa = 1
    }
}
