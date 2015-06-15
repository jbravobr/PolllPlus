﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Resposta : EntityBase
    {
        public string TextoResposta { get; set; }
        public DateTime? DataResposta { get; set; }

        public virtual Pergunta Pergunta { get; set; }
    }
}
