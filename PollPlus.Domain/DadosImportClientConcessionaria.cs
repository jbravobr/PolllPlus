using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class DadosImportClientConcessionaria : EntityBase
    {
        public string UsuarioEmail { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataUltimaCompra { get; set; }
        public DateTime DataEnvioProgramado { get; set; }
        public DateTime DataUltimoEnvio { get; set; }
    }
}
