using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IService
{
    public interface ISubcategoriaCategoriaService
    {
        Task<bool> InserirSubcategoriaCategoria(SubcategoriaCategoria pr);
        Task<bool> RemoverSubcategoriaCategoria(int id);
        Task<ICollection<SubcategoriaCategoria>> RetornarSubcategoriaCategoriaPorSubcategoria(int subcategoriaId);
        Task<ICollection<SubcategoriaCategoria>> RetornarSubcategoriaCategoriaPorCategoria(int categoriaId);
        Task<ICollection<SubcategoriaCategoria>> RetornarSubcategoriaCategoriaTodos();
    }
}
