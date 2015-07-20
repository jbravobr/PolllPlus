using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleExcelExport;

namespace PollPlus.Models
{
    public class RelUsuariosViewModel
    {
        [ExcelExport("Nome")]
        public string Nome { get; set; }

        [ExcelExport("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [ExcelExport("E-mail")]
        public string Email { get; set; }

        [ExcelExport("Telefone")]
        public string Telefone { get; set; }

        [ExcelExport("Data de criação")]
        public string DataCriacao { get; set; }

        [ExcelExport("Município")]
        public string Municipio { get; set; }

        [ExcelExport("Sexo")]
        public string Sexo { get; set; }
    }
}
