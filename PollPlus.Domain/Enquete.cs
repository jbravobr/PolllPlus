using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Enquete : EntityBase
    {
        public string Titulo { get; protected set; }
        public EnumStatusEnquete Status { get; protected set; }
        public EnumTipoEnquete Tipo { get; protected set; }
        public EnumTipoImagem TipoImagem { get; protected set; }
        public string Imagem { get; protected set; }
        public int ClientId { get; protected set; }
        public string UrlVideo { get; protected set; }

        public virtual Usuario UsuarioCriador { get; protected set; }
        public virtual Empresa EmpresaProprietaria { get; protected set; }
        public virtual ICollection<Categoria> Categorias { get; protected set; }
        public virtual Pergunta Pergunta { get; protected set; }
       
    }
}
