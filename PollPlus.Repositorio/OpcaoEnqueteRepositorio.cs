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
    public class OpcaoEnqueteRepositorio : BaseRepositorio<OpcaoEnquete, PollPlusContext<OpcaoEnquete>>, IOpcaoEnqueteRepositorio
    {
        /// <summary>
        /// Método para Salvar uma OpcaoEnquete
        /// </summary>
        /// <param name="e">OpcaoEnquete</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirOpcaoEnquete(OpcaoEnquete e)
        {
            this.Inserir(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Atualizar uma OpcaoEnquete
        /// </summary>
        /// <param name="e">OpcaoEnquete</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>

        public async Task<bool> AtualizarOpcaoEnquete(OpcaoEnquete e)
        {
            this.Atualizar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Deletar uma opção de enquete
        /// </summary>
        /// <param name="e">OpcaoEnquete</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarOpcaoEnquete(OpcaoEnquete e)
        {
            this.Deletar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma opção pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto OpcaoEnquete</returns>
        public async Task<OpcaoEnquete> RetornarOpcaoEnquetePorId(int id)
        {
            Expression<Func<OpcaoEnquete, bool>> porId = (x) => x.Id == id;
            return await this.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma OpcaoEnquete pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto OpcaoEnquete</returns>
        public async Task<ICollection<OpcaoEnquete>> RetornarTodasOpcoesEnquetes()
        {
            return await this.RetornarTodos();
        }
    }
}
