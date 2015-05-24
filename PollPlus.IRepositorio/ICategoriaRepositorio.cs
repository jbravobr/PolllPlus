using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface ICategoriaRepositorio
    {
        Task<bool> InserirCategoria(Categoria e);
        Task<bool> AtualizarCategoria(Categoria e);
        Task<bool> DeletarCategoria(Categoria e);
        Task<Categoria> RetornarCategoriaPorId(int id);
        Task<ICollection<Categoria>> RetornarTodasCategorias();
    }
}
