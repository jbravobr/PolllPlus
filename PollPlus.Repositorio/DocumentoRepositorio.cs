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
    public class DocumentoRepositorio : BaseRepositorio<Documento, PollPlusContext<Documento>>, IDocumentoRepositorio
    {
        /// <summary>
        /// Método para Salvar um Documento
        /// </summary>
        /// <param name="e">Documento</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirDocumento(Documento e)
        {
            this.Inserir(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Atualizar um Documento
        /// </summary>
        /// <param name="e">Documento</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>

        public async Task<bool> AtualizarDocumento(Documento e)
        {
            this.Atualizar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Deletar um Documento
        /// </summary>
        /// <param name="e">Documento</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarDocumento(Documento e)
        {
            this.Deletar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para retorno de um documento pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Documento</returns>
        public async Task<Documento> RetornarDocumentoPorId(int id)
        {
            Expression<Func<Documento, bool>> porId = (x) => x.Id == id;
            return await this.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de um Documento pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Documento</returns>
        public async Task<ICollection<Documento>> RetornarTodosDocumentos()
        {
            return await this.RetornarTodos();
        }
    }
}
