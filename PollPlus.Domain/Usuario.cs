using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Usuario : EntityBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EnumSexo Sexo { get; set; }
        public int DDD { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Municipio { get; set; }
        public EnumStatusUsuario Status { get; set; }
        public EnumPerfil Perfil { get; set; }

        public virtual ICollection<Categoria> CategoriasInteresse { get; set; }
        public virtual ICollection<Geolocalizacao> Localizacoes { get; set; }
        public virtual ICollection<Plataforma> Plataformas { get; set; }

        public void AdicionaCategoria(Categoria cat)
        {
            if (this.CategoriasInteresse == null)
                this.CategoriasInteresse = new List<Categoria>();

            this.CategoriasInteresse.Add(cat);
        }
    }
}
