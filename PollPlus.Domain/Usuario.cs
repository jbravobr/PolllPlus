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
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string Senha { get; protected set; }
        public EnumSexo Sexo { get; protected set; }
        public int DDD { get; protected set; }
        public string Telefone { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public string Municipio { get; protected set; } //TODO: Analisar como será a inclusão e Municipios
        public EnumStatusUsuario Status { get; protected set; }
        public EnumPerfil Perfil { get; set; }

        public virtual Categoria CategoriaInteresse { get; protected set; }
        public virtual ICollection<Geolocalizacao> Localizacoes { get; protected set; }
        public virtual ICollection<Plataforma> Plataformas { get; protected set; }
    }
}
