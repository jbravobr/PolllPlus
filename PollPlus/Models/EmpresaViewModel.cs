using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PollPlus.Models
{
    public class EmpresaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Logo { get; set; }
        public int QtdePush { get; set; }
        public string SubDominio { get; set; }
        public string Css { get; set; }
        public HttpPostedFileBase file { get; set; }

        public PlataformaViewModel Plataforma { get; set; }
        public DocumentoViewModel Documento { get; set; }
    }
}
