using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleExcelExport;

namespace PollPlus.Models
{
    public class RelEnquetesViewModel
    {
        [ExcelExport("ID")]
        public int Id { get; set; }

        [ExcelExport("Pergunta")]
        public string TextoPergunta { get; set; }

        [ExcelExport("Categoria")]
        public string Categoria { get; set; }

        [ExcelExport("Possui Voucher?")]
        public string TemVoucher { get; set; }

        [ExcelExport("Link do vídeo")]
        public string UrlVideo { get; set; }

        [ExcelExport("Arquivo da imagem")]
        public string Imagem { get; set; }

        [ExcelExport("Status")]
        public string Status { get; set; }

        [ExcelExport("Data de criação")]
        public string DataCriacao { get; set; }
    }
}
