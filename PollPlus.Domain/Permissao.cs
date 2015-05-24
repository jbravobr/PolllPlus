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
        public bool Inclusao { get; protected set; }
        public bool Atualizacao { get; protected set; }
        public bool Exclusao { get; protected set; }
        public bool Consulta { get; protected set; }
        public EnumPerfil Perfil { get; protected set; }
    }
}
