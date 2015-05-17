using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain.Enumeradores
{
    public enum EnumStatusVoucher
    {
        [Description("Disponível")]
        Disponivel = 0,

        [Description("Indisponível")]
        Indisponivel = 1
    }
}
