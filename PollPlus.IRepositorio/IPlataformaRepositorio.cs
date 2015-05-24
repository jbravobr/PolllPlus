using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IPlataformaRepositorio
    {
        Task<bool> InserirPlataforma(Plataforma e);
        Task<bool> AtualizarPlataforma(Plataforma e);
        Task<bool> DeletarPlataforma(Plataforma e);
        Task<Plataforma> RetornarPlataformaPorId(int id);
        Task<ICollection<Plataforma>> RetornarTodasPlataformas();
    }
}

