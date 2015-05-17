using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain.Enumeradores
{
    public enum EnumTipoMensagem
    {
        [Description("Push Notification")]
        Push = 0,

        [Description("Mensagem Interna")]
        Interna = 1
    }
}
