using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PollPlus.Models
{
    public class EnqueteViewModel
    {
        public int Id { get; set; }
        public bool TemVoucher { get; set; }
        public int EmpresaId { get; set; }
        public int UsuarioId { get; set; }
        public EnumTipoEnquete Tipo { get; set; }
        public string file { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public PerguntaViewModel Pergunta { get; set; }
    }
}
