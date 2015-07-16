﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class UsuarioCategoria : EntityBase
    {
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
