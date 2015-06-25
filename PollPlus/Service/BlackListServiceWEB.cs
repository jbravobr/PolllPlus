using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IService;
using PollPlus.Models;
using PollPlus.Domain.Enumeradores;
using PollPlus.Helpers;

namespace PollPlus.Service
{
    public class BlackListServiceWEB : IBlackListServiceWEB
    {
        readonly IBlackListService service;

        public BlackListServiceWEB(IBlackListService _service)
        {
            this.service = _service;
        }

        public async Task<bool> InserirBlackList(BlackList b)
        {
            return await this.service.InserirBlackList(b);
        }
    }
}
