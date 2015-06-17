using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Service.Interfaces
{
    public interface IUsuarioServiceWEB
    {
        Task<bool> InserirUsuario(Usuario usuario);
        Task<Usuario> InserirRetornarUsuario(Usuario usuario);
        Task<bool> AtualizarUsuario(Usuario usuario);
        Task<bool> DeletarUsuario(Usuario usuario);
        Task<Usuario> RetornarUsuarioPorId(int id);
        Task<ICollection<Usuario>> RetornarTodosUsuarios();

        Task<ICollection<Categoria>> RetornarCategoriasDisponniveis();

        Task<bool> InserirUsuarioCategoria(UsuarioCategoria uc);

        Task<bool> LogarUsuario(string usuario, string senha);
    }
}
