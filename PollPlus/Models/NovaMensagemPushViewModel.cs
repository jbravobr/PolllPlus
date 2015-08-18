using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Models
{
    public class NovaMensagemPushViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(500, ErrorMessage = "A nova mensagem precisa conter no máximo 500 caracteres.")]
        public String Mensagem { get; set; }

        public string Area { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
