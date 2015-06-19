using PollPlus.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using System.Linq.Expressions;
using PollPlus.IService;

namespace PollPlus.Service
{
    public class UsuarioPlataformaiaService : IUsuarioPlataformaService
    {
        readonly IUsuarioPlataformaRepositorio _repositorio;

        public UsuarioPlataformaiaService(IUsuarioPlataformaRepositorio repo)
        {
            this._repositorio = repo;
        }

        public async Task<bool> InserirUsuarioPlataforma(UsuarioPlataforma ec)
        {
            return await this._repositorio.InserirUsuarioPlataforma(ec);
        }

        public async Task<bool> RemoverUsuarioPlataforma(int id)
        {
            return await this._repositorio.RemoverUsuarioPlataforma(id);
        }

        public async Task<ICollection<UsuarioPlataforma>> RetornarUsuarioPlataformaPorUsuario(int usuarioId)
        {
            return await this._repositorio.RetornarUsuarioPlataformaPorUsuario(usuarioId);
        }

        public async Task<ICollection<UsuarioPlataforma>> RetornarUsuarioPlataformaPorPlataforma(int plataformaId)
        {
            return await this._repositorio.RetornarUsuarioPlataformaPorPlataforma(plataformaId);
        }

        public async Task<ICollection<UsuarioPlataforma>> RetornarUsuarioPlataformaTodos()
        {
            return await this._repositorio.RetornarUsuarioPlataformaTodos();
        }
    }
}
