using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Service.Interfaces
{
    public interface IBlackListServiceWEB
    {
        Task<bool> InserirBlackList(BlackList b);
    }
}
