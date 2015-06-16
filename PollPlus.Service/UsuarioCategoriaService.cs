using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IRepositorio;

namespace PollPlus.Service
{
    public class UsuarioCategoriaService : IUsuarioCategoriaService
    {
        readonly IUsuarioCategoriaRepositorio _repositorio;

        public UsuarioCategoriaService(IUsuarioCategoriaRepositorio repo)
        {
            this._repositorio = repo;
        }

        public async Task<bool> InserirUsuarioCategoria(UsuarioCategoria uc)
        {
            return await this._repositorio.InserirUsuarioCategoria(uc);
        }

        public async Task<bool> RemoverUsuarioCategoria(int Id)
        {
            return await this._repositorio.RemoverUsuarioCategoria(Id);
        }

        public async Task<ICollection<UsuarioCategoria>> RetornarUsuarioCategoriaPorCategoria(int CategoriaId)
        {
            return await this._repositorio.RetornarUsuarioCategoriaPorCategoria(CategoriaId);
        }

        public async Task<ICollection<UsuarioCategoria>> RetornarUsuarioCategoriaPorCategorias(ICollection<int> CategoriasId)
        {
            return await this._repositorio.RetornarUsuarioCategoriaPorCategorias(CategoriasId);
        }

        public async Task<ICollection<UsuarioCategoria>> RetornarUsuarioCategoriaPorUsuario(int UsuarioId)
        {
            return await this._repositorio.RetornarUsuarioCategoriaPorUsuario(UsuarioId);
        }
    }
}
