using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;

namespace PollPlus.Service
{
    public class OpcaoEnqueteService : IOpcaoEnqueteService
    {

        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IOpcaoEnqueteService _servico;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="servico">IOpcaoEnqueteService</param>
        public OpcaoEnqueteService(IOpcaoEnqueteService servico)
        {
            this._servico = servico;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção da OpcaoEnqueteService
        /// </summary>
        /// <param name="e">Objeto OpcaoEnqueteService para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirOpcaoEnquete(OpcaoEnquete e)
        {
            return await this._servico.InserirOpcaoEnquete(e);
        }

        /// <summary>
        /// Método para Atualizar uma OpcaoEnquete
        /// </summary>
        /// <param name="e">OpcaoEnquete</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarOpcaoEnquete(OpcaoEnquete e)
        {
            return await this._servico.AtualizarOpcaoEnquete(e);
        }

        /// <summary>
        /// Método para Deletar uma OpcaoEnquete
        /// </summary>
        /// <param name="e">OpcaoEnquete</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarOpcaoEnquete(OpcaoEnquete e)
        {
            return await this._servico.DeletarOpcaoEnquete(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno da OpcaoEnquete pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da OpcaoEnquete no Banco de Dados</param>
        /// <returns>Objeto OpcaoEnquete</returns>
        public async Task<OpcaoEnquete> RetornarOpcaoEnquetePorId(int id)
        {
            return await this._servico.RetornarOpcaoEnquetePorId(id);
        }

        /// <summary>
        /// Método para retorno de uma OpcaoEnquete pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto OpcaoEnquete</returns>
        public async Task<ICollection<OpcaoEnquete>> RetornarTodasOpcoesEnquetes()
        {
            return await this._servico.RetornarTodasOpcoesEnquetes();
        }
    }
}
