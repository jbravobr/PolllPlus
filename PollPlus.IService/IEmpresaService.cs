using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;

namespace PollPlus.IService
{
    public interface IEmpresaService
    {
        Task<bool> InserirEmpresa(Empresa e);
        Task<bool> AtualizarEmpresa(Empresa e);
        Task<bool> DeletarEmpresa(Empresa e);
        Task<Empresa> RetornarEmpresaPorId(int id);
        Task<ICollection<Empresa>> RetornarTodasEmpresas();
    }
}
