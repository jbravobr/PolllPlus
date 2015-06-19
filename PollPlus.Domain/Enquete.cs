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
        public EnumTipoEnquete Tipo { get; protected set; }
        public EnumTipoImagem TipoImagem { get; set; }
        public string Imagem { get; set; }
        public int ClientId { get; set; }
        public string UrlVideo { get; set; }
        public bool TemVoucher { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        public int PerguntaId { get; set; }
        public virtual Pergunta Pergunta { get; set; }

        public virtual ICollection<EnqueteCategoria> EnqueteCategoria { get; set; }
        public virtual ICollection<EnqueteVoucher> EnqueteVoucher { get; set; }

        public void ConfiguraTipo(EnumTipoEnquete tipo)
        {
            this.Tipo = tipo;
        }
    }
}
