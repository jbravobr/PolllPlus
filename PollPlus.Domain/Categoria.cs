using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Categoria : EntityBase
    {
        public string Nome { get; protected set; }
        public EnumStatusCategoria Status { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Enquete> Enquetes { get; set; }
        public virtual ICollection<Mensagem> Mensagens { get; set; }
        public virtual ICollection<Subcategoria> Subcategorias { get; set; }
    }
}
