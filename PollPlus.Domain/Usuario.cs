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
        public EnumStatusUsuario Status { get; protected set; }
        public EnumPerfil Perfil { get; protected set; }

        public virtual ICollection<UsuarioCategoria> UsuarioCategoria { get; protected set; }
        public virtual ICollection<UsuarioGeolocalizacao> UsuarioGeolocalizacao { get; set; }
        public virtual ICollection<UsuarioPlataforma> UsuarioPlataforma { get; set; }

        public void InativarUsuario()
        {
            this.Status = EnumStatusUsuario.Inativo;
        }

        public Usuario()
        {
            this.Status = EnumStatusUsuario.Ativo;
            this.Perfil = EnumPerfil.AdministradorEmpresa;
        }

        public void AdicionarCategoria(List<int> listaDeCategoriasId)
        {
            if (this.UsuarioCategoria != null)
            {
                this.UsuarioCategoria = new List<UsuarioCategoria>();
            }

            foreach (var cat in listaDeCategoriasId)
            {
                this.UsuarioCategoria.Add(new UsuarioCategoria { CategoriaId = cat, UsuarioId = this.Id });
            }
        }
    }
}
