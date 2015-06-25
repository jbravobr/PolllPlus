using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;

namespace PollPlus.IService
{
    public interface IBlackListService
    {
        Task<bool> InserirBlackList(BlackList b);
    }
}
