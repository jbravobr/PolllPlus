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
    public class ControleAcessoRepositorio : BaseRepositorio<ControleAcesso, PollPlusContext<ControleAcesso>>
    {
        /// <summary>
        /// Método para Salvar uma Empresa
        /// </summary>
        /// <param name="e">Empresa</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirNovoControleAcesso(ControleAcesso e)
        {
            this.Inserir(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Atualizar uma Empresa
        /// </summary>
        /// <param name="e">Empresa</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>

        public async Task<bool> AtualizarControleAcesso(ControleAcesso e)
        {
            this.Atualizar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Deletar uma Empresa
        /// </summary>
        /// <param name="e">Empresa</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarControleAcesso(ControleAcesso e)
        {
            this.Deletar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma Empresa pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Empresa</returns>
        public async Task<ControleAcesso> RetornarControleAcessoPorId(int id)
        {
            Expression<Func<ControleAcesso, bool>> porId = (x) => x.Id == id;
            return await this.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma Empresa pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Empresa</returns>
        public async Task<ICollection<ControleAcesso>> RetornarTodosControleAcesso()
        {
            return await this.RetornarTodos();
        }
    }
}
