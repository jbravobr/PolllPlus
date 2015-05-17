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
        public string Texto { get; protected set; }
        public int AlcanceEmKm { get; protected set; }
        public bool EhRascunho { get; protected set; }
        public EnumTipoMensagem Tipo { get; protected set; }

        public virtual ICollection<Categoria> Categorias { get; protected set; }
        public virtual ICollection<Empresa> Empresas { get; protected set; }
        public virtual ICollection<Plataforma> Plataformas { get; protected set; }
    }
}
