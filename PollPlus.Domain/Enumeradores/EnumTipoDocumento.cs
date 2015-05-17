using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain.Enumeradores
{
    public enum EnumTipoDocumento
    {
        [Description("CNPJ")]
        Cnpj = 0,

        [Description("CPF")]
        Cpf = 1
    }
}
