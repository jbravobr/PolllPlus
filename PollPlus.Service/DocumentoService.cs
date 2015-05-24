using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;


namespace PollPlus.Service
{
    public class DocumentoService : IDocumentoService
    {

        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IDocumentoService _servico;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="servico">IDocumentoService</param>
        public DocumentoService(IDocumentoService servico)
        {
            this._servico = servico;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção do Documento
        /// </summary>
        /// <param name="e">Objeto Documento para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirDocumento(Documento e)
        {
            return await this._servico.InserirDocumento(e);
        }

        /// <summary>
        /// Método para Atualizar um  Documento
        /// </summary>
        /// <param name="e">Documento</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarDocumento(Documento e)
        {
            return await this._servico.AtualizarDocumento(e);
        }

        /// <summary>
        /// Método para Deletar um Documento
        /// </summary>
        /// <param name="e">Documento</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarDocumento(Documento e)
        {
            return await this._servico.DeletarDocumento(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno do Documento pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da Documento no Banco de Dados</param>
        /// <returns>Objeto Documento</returns>
        public async Task<Documento> RetornarDocumentoPorId(int id)
        {
            return await this._servico.RetornarDocumentoPorId(id);
        }

        /// <summary>
        /// Método para retorno de uma Documento pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Documento</returns>
        public async Task<ICollection<Documento>> RetornarTodosDocumentos()
        {
            return await this._servico.RetornarTodosDocumentos();
        }
    }
}
