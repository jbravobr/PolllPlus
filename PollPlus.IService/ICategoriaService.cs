using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
namespace PollPlus.IService
{
    public interface ICategoriaService
    {
        Task<bool> InserirCategoria(Categoria e);
        Task<bool> AtualizarCategoria(Categoria e);
        Task<bool> DeletarCategoria(Categoria e);
        Task<Categoria> RetornarCategoriaPorId(int id);
        Task<ICollection<Categoria>> RetornarTodasCategorias();
    }
}
