using PollPlus.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class Permissao : EntityBase
    {
        public bool Inclusao { get; set; }
        public bool Atualizacao { get; set; }
        public bool Exclusao { get; set; }
        public bool Consulta { get; set; }
        public EnumPerfil Perfil { get; set; }
    }
}
