using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class AmigoEnquete : EntityBase
    {
        public int UsuarioId {get;set;}
        public Usuario Usuario { get; set; }

        public int EnqueteId { get; set; }
        public Enquete Enquete { get; set; }
    }
}
