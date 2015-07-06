using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class CategoriaBanner : EntityBase
    {
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public int BannerId { get; set; }
        public virtual Banner Banner { get; set; }
    }
}
