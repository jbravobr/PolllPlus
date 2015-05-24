using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IService
{
    public interface IUsuarioService
    {
        Task<bool> InserirUsuario(Usuario e);
        Task<bool> AtualizarUsuario(Usuario e);
        Task<bool> DeletarUsuario(Usuario e);
        Task<Usuario> RetornarUsuarioPorId(int id);
        Task<ICollection<Usuario>> RetornarTodosUsuarios();
    }
}
