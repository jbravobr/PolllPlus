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
    public class AmigoEnqueteRepositorio : BaseRepositorio<AmigoEnquete, PollPlusContext<AmigoEnquete>>
    {
        /// <summary>
        /// Método para Salvar uma Banner
        /// </summary>
        /// <param name="e">Banner</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirAmigoEnquete(AmigoEnquete e)
        {
            base.Inserir(e);
            return await base.Salvar();
        }

        public async Task<AmigoEnquete> InserirRetornarAmigoEnquete(AmigoEnquete e)
        {
            return await base.InsertAndReturnEntity(e);
        }

        public async Task<bool> AtualizarAmigoEnquete(AmigoEnquete e)
        {
            base.Atualizar(e);
            return await base.Salvar();
        }

        /// <summary>
        /// Método para Deletar uma Banner
        /// </summary>
        /// <param name="e">Banner</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarAmigoEnquete(AmigoEnquete e)
        {
            base.Deletar(e);
            return await base.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma Banner pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Banner</returns>
        public async Task<AmigoEnquete> RetornarAmigoEnquetePorEnquete(int enqueteId)
        {
            Expression<Func<AmigoEnquete, bool>> porId = (x) => x.EnqueteId == enqueteId;
            return await base.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma Banner pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Banner</returns>
        public async Task<ICollection<AmigoEnquete>> RetornarTodosAmigoEnquete()
        {
            return await base.RetornarTodos();
        }
    }
}
