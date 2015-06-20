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
    public class RespostaRepositorio : BaseRepositorio<Resposta, PollPlusContext<Resposta>>, IRespostaRepositorio
    {
        /// <summary>
        /// Método para Salvar um Resposta
        /// </summary>
        /// <param name="e">Resposta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirResposta(Resposta e)
        {
            this.Inserir(e);
            return await this.Salvar();
        }

        public async Task<Resposta> InserirRetornarResposta(Resposta e)
        {
            return await this.InsertAndReturnEntity(e);
        }

        /// <summary>
        /// Método para Atualizar um Resposta
        /// </summary>
        /// <param name="e">Resposta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>

        public async Task<bool> AtualizarResposta(Resposta e)
        {
            this.Atualizar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Deletar um Resposta
        /// </summary>
        /// <param name="e">Resposta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarResposta(Resposta e)
        {
            this.Deletar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para retorno de um Resposta pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Resposta</returns>
        public async Task<Resposta> RetornarRespostaPorId(int id)
        {
            Expression<Func<Resposta, bool>> porId = (x) => x.Id == id;
            return await this.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de um Resposta pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Resposta</returns>
        public async Task<ICollection<Resposta>> RetornarTodasRespostas()
        {
            return await this.RetornarTodos();
        }
    }
}
