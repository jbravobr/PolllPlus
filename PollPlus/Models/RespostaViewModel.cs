using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Models
{
    public class RespostaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(150)]
        public string TextoResposta { get; set; }
        public bool correta { get; set; }

        public int PerguntaId { get; set; }
    }
}
