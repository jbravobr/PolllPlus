﻿using PollPlus.Domain;
using PollPlus.IRepositorio;
using PollPlus.Repositorio.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario, PollPlusContext<Usuario>>, IUsuarioRepositorio
    {
        /// <summary>
        /// Método para Salvar um usuário
        /// </summary>
        /// <param name="e">Usuario</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirUsuario(Usuario e)
        {
            this.Inserir(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Atualizar uma usuário
        /// </summary>
        /// <param name="e">Usuario</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>

        public async Task<bool> AtualizarUsuario(Usuario e)
        {
            this.Atualizar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Deletar um usuario
        /// </summary>
        /// <param name="e">Usuario</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarUsuario(Usuario e)
        {
            this.Deletar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para retorno de um Usuario pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Usuario</returns>
        public async Task<Usuario> RetornarUsuarioPorId(int id)
        {
            Expression<Func<Usuario, bool>> porId = (x) => x.Id == id;
            return await this.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de um Usuario pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Usuario</returns>
        public async Task<ICollection<Usuario>> RetornarTodosUsuarios()
        {
            return await this.RetornarTodos();
        }
    }
}
