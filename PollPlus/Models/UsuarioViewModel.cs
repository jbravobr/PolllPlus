using PollPlus.Domain;
using PollPlus.Domain.Enumeradores;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PollPlus.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "E-mail digitado é inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MinLength(6, ErrorMessage = "Insira 6 ou mais caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public EnumSexo Sexo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int DDD { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Municipio { get; set; }

        public EnumStatusUsuario Status { get; set; }
        public EnumPerfil Perfil { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int EmpresaId { get; set; }

        public ICollection<UsuarioCategoria> UsuarioCategoria { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public List<int> CategoriasInteresse { get; set; }

        public List<SelectListItem> CategoriasForSelectList { get; set; }

        public List<SelectListItem> EmpresasForSelectList { get; set; }
    }
}
