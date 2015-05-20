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
        Task<Enquete> RetornarEnquenetePorId(int id);
    }
}
