using SimpleExcelExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PollPlus.Models
{
    public class RelEmpresaViewModel
    {
        [ExcelExport("Nome")]
        public string Nome { get; set; }

        [ExcelExport("Documento")]
        public string Documento { get; set; }

        [ExcelExport("Data de Criação")]
        public string DataCriacao { get; set; }
    }
}