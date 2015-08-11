using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PollPlus.Domain.Enumeradores
{
    public enum EnumPerfil
    {
        [Description("Administrador Master")]
        AdministradorMaster = 0,

        [Description("Administrador Empresa")]
        AdministradorEmpresa = 1,

        [Description("Usuario App")]
        UsuarioApp = 2,

        [Description("Vendedor")]
        Vendedor = 3,
    }
}
