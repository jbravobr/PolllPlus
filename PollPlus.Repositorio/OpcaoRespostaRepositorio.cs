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
    public class OpcaoRespostaRepositorio : BaseRepositorio<OpcaoResposta, PollPlusContext<OpcaoResposta>>, IOpcaoRespostaRepositorio
    {
        /// <summary>
        /// Método para Salvar uma OpcaoResposta
        /// </summary>
        /// <param name="e">OpcaoResposta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirOpcaoResposta(OpcaoResposta e)
        {
            this.Inserir(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Atualizar uma OpcaoResposta
        /// </summary>
        /// <param name="e">OpcaoResposta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>

        public async Task<bool> AtualizarOpcaoResposta(OpcaoResposta e)
        {
            this.Atualizar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Deletar uma OpcaoResposta
        /// </summary>
        /// <param name="e">OpcaoResposta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarOpcaoResposta(OpcaoResposta e)
        {
            this.Deletar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma OpcaoResposta pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto OpcaoResposta</returns>
        public async Task<OpcaoResposta> RetornarOpcaoRespostaPorId(int id)
        {
            Expression<Func<OpcaoResposta, bool>> porId = (x) => x.Id == id;
            return await this.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma OpcaoResposta pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto OpcaoResposta</returns>
        public async Task<ICollection<OpcaoResposta>> RetornarTodasOpcoesRespostas()
        {
            return await this.RetornarTodos();
        }
    }
}
