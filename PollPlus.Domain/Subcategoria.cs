using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PollPlus.Domain
{
    public class Subcategoria : EntityBase
    {
        public string NomeSubCategoria { get; protected set; }
        public int CategoriaId { get; protected set; }
        public Categoria Categoria { get; protected set; }
    }
}
