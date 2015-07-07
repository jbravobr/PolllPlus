using Newtonsoft.Json;
using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Banner : EntityBase
    {
        public string FileName { get; set; }
        public string Url { get; set; }
        public DateTime DataValidade { get; set; }

        public EnumStatusUsuario Status { get; set; }

        [JsonIgnore]
        public virtual ICollection<CategoriaBanner> CategoriaBanner { get; set; }
        [JsonIgnore]
        public virtual ICollection<EmpresaBanner> EmpresaBanner { get; set; }
    }
}
