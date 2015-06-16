using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IUsuarioCategoriaRepositorio
    {
        Task<bool> InserirUsuarioCategoria(UsuarioCategoria uc);
        Task<bool> RemoverUsuarioCategoria(int Id);
        Task<ICollection<UsuarioCategoria>> RetornarUsuarioCategoriaPorUsuario(int UsuarioId);
        Task<ICollection<UsuarioCategoria>> RetornarUsuarioCategoriaPorCategoria(int CategoriaId);
        Task<ICollection<UsuarioCategoria>> RetornarUsuarioCategoriaPorCategorias(ICollection<int> CategoriasId);
    }
}
