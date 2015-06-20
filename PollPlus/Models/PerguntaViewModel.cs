using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Models
{
    public class PerguntaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(240)]
        public string TextoPergunta { get; set; }

        public ICollection<RespostaViewModel> Resposta { get; set; }
    }
}
