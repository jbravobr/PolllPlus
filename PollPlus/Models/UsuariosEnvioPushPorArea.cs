using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Models
{
    public class UsuariosEnvioPushPorArea
    {
        public string Nome { get; set; }
        public string NomeEmpresa { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataHoraEnvio { get; set; }
        public string EnderecoOrigem { get; set; }
    }
}
