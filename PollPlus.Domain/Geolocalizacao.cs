using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Geolocalizacao : EntityBase
    {
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }
    }
}
