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
    public class EnqueteRepositorio : BaseRepositorio<Enquete, PollPlusContext<Enquete>>, IEnqueteRepositorio
    {
        /// <summary>
        /// Método para Salvar uma enquete
        /// </summary>
        /// <param name="e">Enquete</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirEnquete(Enquete e)
        {
            this.Inserir(e);
            return await this.Salvar();
        }

        public async Task<Enquete> InserirRetornarEnquete(Enquete e)
        {
            return await this.InsertAndReturnEntity(e);
        }


        /// <summary>
        /// Método para Atualizar uma enquete
        /// </summary>
        /// <param name="e">Enquete</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>

        public async Task<bool> AtualizarEnquete(Enquete e)
        {
            this.Atualizar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Deletar uma enquete
        /// </summary>
        /// <param name="e">Enquete</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarEnquete(Enquete e)
        {
            this.Deletar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma Enquete pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Enquete</returns>
        public async Task<Enquete> RetornarEnquetePorId(int id)
        {
            Expression<Func<Enquete, bool>> porId = (x) => x.Id == id;
            return await this.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma Enquete pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Enquete</returns>
        public async Task<ICollection<Enquete>> RetornarTodasEnquetes()
        {
            return await this.RetornarTodos();
        }

        public async Task<ICollection<Enquete>> RetornarTodosOsQuiz()
        {
            Expression<Func<Enquete, bool>> quiz = (x) => x.Tipo == Domain.Enumeradores.EnumTipoEnquete.Quiz;

            return await base.ProcurarPorColecao(quiz);
        }
    }
}
