using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class SubcategoriaCategoria : EntityBase
    {
        public int SubcategoriaId { get; set; }
        public Subcategoria Subcategoria { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
