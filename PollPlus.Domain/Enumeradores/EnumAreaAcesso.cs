using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain.Enumeradores
{
    public enum EnumAreaAcesso
    {
        [Description("Banners")]
        Banner = 1,

        [Description("Geofence - Entrar na zona")]
        GeofenceEntrar = 2,

        [Description("Geofence - Saiu da zona")]
        GeofenceSaiu = 3,

        [Description("Geofence - Permanecer na zona")]
        GeofencePermaneceu = 4
    }
}
