using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IService;
using PollPlus.Helpers;
using PollPlus.Domain.Enumeradores;

namespace PollPlus.Service
{
    public class UsuarioServiceWEB : IUsuarioServiceWEB
    {
        readonly IUsuarioService _service;

        readonly ICategoriaService _serviceCategoria;

        readonly IUsuarioCategoriaService _serviceUsuarioCategoria;

        public UsuarioServiceWEB(IUsuarioService Service, ICategoriaService ServiceCategoria, IUsuarioCategoriaService ServiceUsuarioCategoria)
        {
            this._service = Service;
            this._serviceCategoria = ServiceCategoria;
            this._serviceUsuarioCategoria = ServiceUsuarioCategoria;
        }

        public async Task<bool> AtualizarUsuario(Usuario usuario)
        {
            return await this._service.AtualizarUsuario(usuario);
        }

        public async Task<bool> DeletarUsuario(Usuario usuario)
        {
            return await this._service.DeletarUsuario(usuario);
        }

        public async Task<Usuario> InserirRetornarUsuario(Usuario usuario)
        {
            return await this._service.InserirRetornarUsuario(usuario);
        }

        public async Task<bool> InserirUsuario(Usuario usuario)
        {
            return await this._service.InserirUsuario(usuario);
        }

        public async Task<bool> InserirUsuarioCategoria(UsuarioCategoria uc)
        {
            return await this._serviceUsuarioCategoria.InserirUsuarioCategoria(uc);
        }

        public async Task<bool> LogarUsuario(string usuario, string senha)
        {
            var _usuario = (await this._service.RetornarTodosUsuarios()).FirstOrDefault(u => u.Email == usuario);

            //var senhaDecrypt = Util.DescriptarSenha(_usuario.Senha);

            if (_usuario == null)
                return await Task.FromResult(false);
            else if (_usuario != null && senha == _usuario.Senha)
                return await Task.FromResult(true);
            else
                return await Task.FromResult(false);
        }

        public async Task<ICollection<Categoria>> RetornarCategoriasDisponniveis()
        {
            var _categoria = new List<Categoria>();

            _categoria = (await this._serviceCategoria.RetornarTodasCategorias()).ToList();
            return _categoria;
        }

        public async Task<ICollection<Usuario>> RetornarTodosUsuarios()
        {
            var _usuario = new List<Usuario>();

            _usuario = (await this._service.RetornarTodosUsuarios()).ToList();
            return _usuario;
        }

        public async Task<Usuario> RetornarUsuarioPorId(int id)
        {
            return await this._service.RetornarUsuarioPorId(id);
        }
    }
}
