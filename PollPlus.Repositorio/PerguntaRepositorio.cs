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
    public class PerguntaRepositorio : BaseRepositorio<Pergunta, PollPlusContext<Pergunta>>, IPerguntaRepositorio
    {
        /// <summary>
        /// Método para Salvar um Pergunta
        /// </summary>
        /// <param name="e">Pergunta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirPergunta(Pergunta e)
        {
            this.Inserir(e);
            return await this.Salvar();
        }

        public async Task<Pergunta> InserirRetornarPergunta(Pergunta e)
        {
            return await this.InsertAndReturnEntity(e);
        }

        /// <summary>
        /// Método para Atualizar um Pergunta
        /// </summary>
        /// <param name="e">Pergunta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>

        public async Task<bool> AtualizarPergunta(Pergunta e)
        {
            this.Atualizar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Deletar um Pergunta
        /// </summary>
        /// <param name="e">Pergunta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarPergunta(Pergunta e)
        {
            this.Deletar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para retorno de um Pergunta pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Pergunta</returns>
        public async Task<Pergunta> RetornarPerguntaPorId(int id)
        {
            Expression<Func<Pergunta, bool>> porId = (x) => x.Id == id;
            return await this.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de um Pergunta pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Pergunta</returns>
        public async Task<ICollection<Pergunta>> RetornarTodasPerguntas()
        {
            return await this.RetornarTodos();
        }
    }
}
