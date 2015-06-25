using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IBlackListRepositorio
    {
        Task<bool> InserirBlackList(BlackList b);
    }
}

