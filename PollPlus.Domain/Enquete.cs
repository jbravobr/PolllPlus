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
        public string Titulo { get; set; }
        public EnumStatusEnquete Status { get; set; }
        public EnumTipoEnquete Tipo { get; set; }
        public EnumTipoImagem TipoImagem { get; set; }
        public string Imagem { get; set; }
        public int ClientId { get; set; }
        public string UrlVideo { get; set; }

        public virtual Usuario UsuarioCriador { get; set; }
        public virtual Empresa EmpresaProprietaria { get; set; }
        public virtual ICollection<Categoria> Categorias { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
