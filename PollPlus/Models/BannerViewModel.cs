using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PollPlus.Models
{
    public class BannerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Url { get; set; }
        public int EmpresaId { get; set; }

        public HttpPostedFileBase file { get; set; }
        public string fileName { get; set; }
    }
}
