using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Service.Interfaces
{
    public interface IEnqueteServiceWEB
    {
        Task<bool> InserirEnquete(Enquete e);
        Task<bool> AtualizarEnquete(Enquete e);
        Task<bool> DeletarEnquete(Enquete e);
        Task<Enquete> RetornarEnquetePorId(int id);
        Task<ICollection<Enquete>> RetornarTodasEnquetes();
        Task<ICollection<Categoria>> RetornarCategoriasDisponniveis();
        Task<Enquete> InserirRetornarEnquete(Enquete e);  
        Task<bool> InserirEnqueteCategoria(EnqueteCategoria uc);

    }
}
