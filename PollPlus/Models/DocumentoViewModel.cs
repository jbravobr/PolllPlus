using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Models
{
    public class DocumentoViewModel
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public EnumTipoDocumento Tipo { get; set; }
    }
}
