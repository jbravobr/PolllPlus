using SimpleExcelExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PollPlus.Models
{
    public class RelEnquetesRespostas
    {
        [ExcelExport("ID")]
        public int Id { get; set; }

        [ExcelExport("Pergunta")]
        public string TextoPergunta { get; set; }

        [ExcelExport("Categoria")]
        public string Categoria { get; set; }

        [ExcelExport("Possui Voucher?")]
        public string TextoRespostas { get; set; }

        [ExcelExport("Link do vídeo")]
        public string Percentual { get; set; }
    }
}