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

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public int EmpresaId { get; set; }
    }
}
