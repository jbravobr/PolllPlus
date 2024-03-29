﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Empresa : EntityBase
    {
        public string Nome { get; set; }
        public string Logo { get; set; }
        public int QtdePush { get; set; }
        public string SubDominio { get; set; }
        public string Css { get; set; }

        public int DocumentoId { get; set; }
        public virtual Documento Documento { get; set; }

        public int PlataformaId { get; set; }
        public virtual Plataforma Plataforma { get; set; }

        public virtual ICollection<Mensagem> Mensagem { get; set; }
        [JsonIgnore]
        public virtual ICollection<EmpresaBanner> EmpresaBanner { get; set; }

        public string AppKeyForPush { get; set; }
        public string AppPassForPush { get; set; }

        [JsonIgnore]
        public virtual ICollection<Filial> Filial { get; set; }
    }
}
