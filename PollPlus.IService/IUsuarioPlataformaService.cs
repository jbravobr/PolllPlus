using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IService
{
    public interface IUsuarioPlataformaService
    {
        Task<bool> InserirUsuarioPlataforma(UsuarioPlataforma ev);
        Task<bool> RemoverUsuarioPlataforma(int id);
        Task<ICollection<UsuarioPlataforma>> RetornarUsuarioPlataformaPorUsuario(int usuarioId);
        Task<ICollection<UsuarioPlataforma>> RetornarUsuarioPlataformaPorPlataforma(int plataformaId);
        Task<ICollection<UsuarioPlataforma>> RetornarUsuarioPlataformaTodos();
    }
}
