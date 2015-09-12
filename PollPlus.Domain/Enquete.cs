using Newtonsoft.Json;
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
        public string Descricao { get; set; }
        public EnumStatusEnquete Status { get; set; }
        public EnumTipoEnquete Tipo { get; set; }
        public EnumTipoImagem TipoImagem { get; set; }
        public string Imagem { get; set; }
        public int ClientId { get; set; }
        public string UrlVideo { get; set; }
        public bool TemVoucher { get; set; }
        public int QtdePush { get; set; }
        public bool? AtivaNoFront { get; set; }
        public bool propria { get; set; }

        public string colegas { get; set; }

        public int UsuarioId { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }

        public int? EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        public int? PerguntaId { get; set; }
        public virtual Pergunta Pergunta { get; set; }

        public virtual ICollection<EnqueteCategoria> EnqueteCategoria { get; set; }
        public virtual ICollection<EnqueteVoucher> EnqueteVoucher { get; set; }

        public virtual ICollection<AmigoEnquete> AmigoEnquete { get; set; }

        public void ConfiguraTipo(EnumTipoEnquete tipo)
        {
            this.Tipo = tipo;
        }

        public void AdicionarCategoria(List<int> listaDeCategoriasId)
        {
            if (this.EnqueteCategoria != null)
            {
                this.EnqueteCategoria = new List<EnqueteCategoria>();
            }

            foreach (var cat in listaDeCategoriasId)
            {
                this.EnqueteCategoria.Add(new EnqueteCategoria { CategoriaId = cat, EnqueteId = this.Id });
            }
        }
    }
}
