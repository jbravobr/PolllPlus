using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IService
{
    public interface IEnqueteService
    {
        Task<bool> InserirEnquete(Enquete e);
        Task<Enquete> RetornarEnquetePorId(int id);
    }
}
