using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Service.Interfaces
{
    public interface IEmpresaServiceWEB
    {
        Task<bool> InserirEmpresa(Empresa e);
        Task<bool> AtualizarEmpresa(Empresa e);
        Task<bool> DeletarEmpresa(Empresa e);
        Task<Empresa> RetornarEmpresaPorId(int id);
        Task<ICollection<Empresa>> RetornarTodasEmpresas();
        Task<ICollection<Empresa>> RetornarTodasEmpresasMaster();
    }
}
