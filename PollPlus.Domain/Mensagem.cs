using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Mensagem : EntityBase
    {
        public string Texto { get; set; }
        public int AlcanceEmKm { get; set; }
        public bool EhRascunho { get; set; }
        public EnumTipoMensagem Tipo { get; set; }

        public virtual ICollection<Categoria> Categorias { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
