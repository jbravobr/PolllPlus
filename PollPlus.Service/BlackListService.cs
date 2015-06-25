using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IRepositorio;

namespace PollPlus.Service
{
    public class BlackListService : IBlackListService
    {
        readonly IBlackListRepositorio repo;

        public BlackListService(IBlackListRepositorio r)
        {
            this.repo = r;
        }

        public async Task<bool> InserirBlackList(BlackList b)
        {
            return await this.repo.InserirBlackList(b);
        }
    }
}
