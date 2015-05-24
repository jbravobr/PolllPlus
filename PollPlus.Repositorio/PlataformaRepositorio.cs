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
    public class PlataformaRepositorio : BaseRepositorio<Plataforma, PollPlusContext<Plataforma>>, IPlataformaRepositorio
    {
        /// <summary>
        /// Método para Salvar uma Plataforma
        /// </summary>
        /// <param name="e">Plataforma</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirPlataforma(Plataforma e)
        {
            this.Inserir(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Atualizar uma Plataforma
        /// </summary>
        /// <param name="e">Plataforma</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>

        public async Task<bool> AtualizarPlataforma(Plataforma e)
        {
            this.Atualizar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Deletar uma Plataforma
        /// </summary>
        /// <param name="e">Plataforma</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarPlataforma(Plataforma e)
        {
            this.Deletar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma Plataforma pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Plataforma</returns>
        public async Task<Plataforma> RetornarPlataformaPorId(int id)
        {
            Expression<Func<Plataforma, bool>> porId = (x) => x.Id == id;
            return await this.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma Plataforma pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Plataforma</returns>
        public async Task<ICollection<Plataforma>> RetornarTodasPlataformas()
        {
            return await this.RetornarTodos();
        }
    }
}
