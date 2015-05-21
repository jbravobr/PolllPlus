using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IEnqueteRepositorio
    {
        Task<bool> InserirEnquete(Enquete e);
        Task<bool> AtualizarEnquete(Enquete e);
        Task<bool> DeletarEnquete(Enquete e);
        Task<Enquete> RetornarEnquetePorId(int id);
        Task<ICollection<Enquete>> RetornarTodos();
    }
}
