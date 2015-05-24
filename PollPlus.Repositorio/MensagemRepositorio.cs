using PollPlus.Domain;
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
    public class MensagemRepositorio : BaseRepositorio<Mensagem, PollPlusContext<Mensagem>>, IMensagemRepositorio
    {
        /// <summary>
        /// Método para Salvar uma Mensagem
        /// </summary>
        /// <param name="e">Mensagem</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirMensagem(Mensagem e)
        {
            this.Inserir(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Atualizar uma Mensagem
        /// </summary>
        /// <param name="e">Mensagem</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>

        public async Task<bool> AtualizarMensagem(Mensagem e)
        {
            this.Atualizar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Deletar uma Mensagem
        /// </summary>
        /// <param name="e">Mensagem</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarMensagem(Mensagem e)
        {
            this.Deletar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma Mensagem pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Mensagem</returns>
        public async Task<Mensagem> RetornarMensagemPorId(int id)
        {
            Expression<Func<Mensagem, bool>> porId = (x) => x.Id == id;
            return await this.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma Mensagem pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Mensagem</returns>
        public async Task<ICollection<Mensagem>> RetornarTodasMensagens()
        {
            return await this.RetornarTodos();
        }
    }
}
