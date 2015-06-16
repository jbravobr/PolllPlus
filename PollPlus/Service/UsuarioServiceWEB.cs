﻿using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IService;

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

        public async Task<bool> LogarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Categoria>> RetornarCategoriasDisponniveis()
        {
            return await this._serviceCategoria.RetornarTodasCategorias();
        }

        public async Task<ICollection<Usuario>> RetornarTodosUsuarios()
        {
            return await this._service.RetornarTodosUsuarios();
        }

        public async Task<Usuario> RetornarUsuarioPorId(int id)
        {
            return await this._service.RetornarUsuarioPorId(id);
        }
    }
}
