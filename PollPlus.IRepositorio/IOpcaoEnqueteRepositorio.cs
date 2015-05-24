using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PollPlus.IRepositorio
{
    public interface IOpcaoEnqueteRepositorio
    {
        Task<bool> InserirOpcaoEnquete(OpcaoEnquete e);
        Task<bool> AtualizarOpcaoEnquete(OpcaoEnquete e);
        Task<bool> DeletarOpcaoEnquete(OpcaoEnquete e);
        Task<OpcaoEnquete> RetornarOpcaoEnquetePorId(int id);
        Task<ICollection<OpcaoEnquete>> RetornarTodasOpcoesEnquetes();
    }
}
