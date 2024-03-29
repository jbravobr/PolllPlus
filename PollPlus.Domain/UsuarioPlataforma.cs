﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class UsuarioPlataforma : EntityBase
    {
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }

        public int PlataformaId { get; set; }
        [JsonIgnore]
        public virtual Plataforma Plataforma { get; set; }
    }
}
