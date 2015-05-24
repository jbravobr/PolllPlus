using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;

namespace PollPlus.Service
{
    public class UsuarioService : IUsuarioService
    {
        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IUsuarioService _servico;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="servico">IUsuarioService</param>
        public UsuarioService(IUsuarioService servico)
        {
            this._servico = servico;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção do Usuario
        /// </summary>
        /// <param name="e">Objeto Usuario para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirUsuario(Usuario e)
        {
            return await this._servico.InserirUsuario(e);
        }

        /// <summary>
        /// Método para Atualizar um Usuario
        /// </summary>
        /// <param name="e">Usuario</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarUsuario(Usuario e)
        {
            return await this._servico.AtualizarUsuario(e);
        }

        /// <summary>
        /// Método para Deletar um usuario
        /// </summary>
        /// <param name="e">Usuario</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarUsuario(Usuario e)
        {
            return await this._servico.DeletarUsuario(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno do usuario pelo seu ID
        /// </summary>
        /// <param name="id">Identificação do usuario no Banco de Dados</param>
        /// <returns>Objeto Usuario</returns>
        public async Task<Usuario> RetornarUsuarioPorId(int id)
        {
            return await this._servico.RetornarUsuarioPorId(id);
        }

        /// <summary>
        /// Método para retorno de um Usuariopelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Usuario</returns>
        public async Task<ICollection<Usuario>> RetornarTodosUsuarios()
        {
            return await this._servico.RetornarTodosUsuarios();
        }
    }
}
