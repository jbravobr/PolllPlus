using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PollPlus.Models
{
    public class RelRespostasPorMunicipio
    {
        public int Id { get; set; }
        public string TextoResposta { get; set; }
        public string Municipio { get; set; }
    }
}