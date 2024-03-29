﻿using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IRepositorio;
using PollPlus.Service.Helpers;

namespace PollPlus.Service
{
    public class UsuarioService : IUsuarioService
    {
        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IUsuarioRepositorio _repositorio;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="repositorio">IUsuarioService</param>
        public UsuarioService(IUsuarioRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção do Usuario
        /// </summary>
        /// <param name="e">Objeto Usuario para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirUsuario(Usuario e)
        {
            //if (!String.IsNullOrEmpty(e.Senha))
            //    e.Senha = Util.EncriptarSenha(e.Senha);

            return await this._repositorio.InserirUsuario(e);
        }

        /// <summary>
        /// Método para Atualizar um Usuario
        /// </summary>
        /// <param name="e">Usuario</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarUsuario(Usuario e)
        {
            return await this._repositorio.AtualizarUsuario(e);
        }

        /// <summary>
        /// Método para Deletar um usuario
        /// </summary>
        /// <param name="e">Usuario</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarUsuario(Usuario e)
        {
            return await this._repositorio.DeletarUsuario(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno do usuario pelo seu ID
        /// </summary>
        /// <param name="id">Identificação do usuario no Banco de Dados</param>
        /// <returns>Objeto Usuario</returns>
        public async Task<Usuario> RetornarUsuarioPorId(int id)
        {
            return await this._repositorio.RetornarUsuarioPorId(id);
        }

        /// <summary>
        /// Método para retorno de um Usuariopelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Usuario</returns>
        public async Task<ICollection<Usuario>> RetornarTodosUsuarios()
        {
            return await this._repositorio.RetornarTodosUsuarios();
        }

        /// <summary>
        /// Insere e retornar um usuário
        /// </summary>
        /// <param name="e">Usuário a ser inserido</param>
        /// <returns></returns>
        public async Task<Usuario> InserirRetornarUsuario(Usuario e)
        {
            //e.Senha = Util.EncriptarSenha(e.Senha);

            return await this._repositorio.InserirRetornarUsuario(e);
        }
    }
}
