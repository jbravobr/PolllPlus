using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleExcelExport;

namespace PollPlus.Models
{
    public class RelUsuariosViewModdel
    {
        [ExcelExport("Nome")]
        public string Nome { get; set; }

        [ExcelExport("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [ExcelExport("E-mail")]
        public string Email { get; set; }

        [ExcelExport("Telefone")]
        public string Telefone { get; set; }
    }
}
