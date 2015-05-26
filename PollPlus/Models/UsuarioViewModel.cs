using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Municipio { get; set; } //TODO: Analisar como será a inclusão e Municipios
        public EnumStatusUsuario Status { get; set; }
        public EnumPerfil Perfil { get; set; }

    }
}
