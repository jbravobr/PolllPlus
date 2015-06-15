using PollPlus.Domain;
using PollPlus.Domain.Enumeradores;

using System;
using System.Collections.Generic;

namespace PollPlus.Models
{
    public class UsuarioViewModel
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

        public List<CategoriaViewModel> CategoriasInteresse { get; set; }
    }
}
