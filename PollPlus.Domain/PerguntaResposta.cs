﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class PerguntaResposta : EntityBase
    {
        public int PerguntaId { get; set; }
        [JsonIgnore]
        public virtual Pergunta Pergunta { get; set; }

        public int RespostaId { get; set; }
        [JsonIgnore]
        public virtual Resposta Resposta { get; set; }

        public bool Respondida { get; set; }

        public double percentual { get; set; }

        public int UsuarioId { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
    }
}
