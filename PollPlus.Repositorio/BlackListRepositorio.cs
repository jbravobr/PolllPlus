using PollPlus.Domain;
using PollPlus.IRepositorio;
using PollPlus.Repositorio.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Repositorio
{
    public class BlackListRepositorio : BaseRepositorio<BlackList, PollPlusContext<BlackList>>, IBlackListRepositorio
    {
        public async Task<bool> InserirBlackList(BlackList b)
        {
            base.Inserir(b);
            return await base.Salvar();
        }
    }
}
