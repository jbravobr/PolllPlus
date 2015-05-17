using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Domain
{
    public class OpcaoResposta :EntityBase
    {
        public int OpcaoEnqueteId { get; protected set; }
        public OpcaoEnquete OpcaoEnquete { get; protected set; }

        public int EnqueteId { get; protected set; }
        public Enquete Enquete { get; protected set; }
    }
}
