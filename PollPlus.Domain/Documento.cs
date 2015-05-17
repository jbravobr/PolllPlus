﻿using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Documento : EntityBase
    {
        public int Numero { get; protected set; }
        public EnumTipoDocumento Tipo { get; protected set; }
    }
}
