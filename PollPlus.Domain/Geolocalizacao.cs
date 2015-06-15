using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Geolocalizacao : EntityBase
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
