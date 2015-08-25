using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PollPlus.Models
{
    public class ListaUsuariosEnviadosViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Mensagem { get; set; }
        public string DataProgramada { get; set; }
    }
}