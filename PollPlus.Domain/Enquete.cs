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
        public string PerguntaTitulo { get; protected set; }
        public EnumStatusEnquete Status { get; protected set; }
        public EnumTipoImagem TipoImagem { get; protected set; }
        public string Imagem { get; protected set; }
        
        public virtual Usuario UsuarioCriador { get; protected set; }
        public virtual Empresa EmpresaProprietaria { get; protected set; }
    }
}
