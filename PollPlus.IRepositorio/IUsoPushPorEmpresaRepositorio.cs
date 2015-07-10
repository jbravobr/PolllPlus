using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IUsoPushPorEmpresaRepositorio
    {
        Task<bool> InserirUsoPushPorEmpresa(UsoPushPorEmpresa r);
        Task<bool> DeletarUsoPushPorEmpresa(UsoPushPorEmpresa r);
        Task<bool> AtualizarUsoPushPorEmpresa(UsoPushPorEmpresa r);
        Task<UsoPushPorEmpresa> RetornarUsoPushPorEmpresaPorId(int id);
        Task<UsoPushPorEmpresa> InserirRetornarUsoPushPorEmpresa(UsoPushPorEmpresa r);
    }
}

