using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain.Enumeradores
{
    public enum EnumTipoImagem
    {
        [Description("Enquete")]
        Enquete = 0,

        [Description("Banner")]
        Banner = 1,

        [Description("Logo")]
        Logo = 2
    }
}
