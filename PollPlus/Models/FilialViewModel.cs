using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Models
{
    public class FilialViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public double Latitute { get; set; }
        public double Longitude { get; set; }

        public List<int> Empresa { get; set; }
    }
}
