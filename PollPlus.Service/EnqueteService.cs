using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;

namespace PollPlus.Service
{
    public class EnqueteService : IEnqueteService
    {
        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IEnqueteService _servico;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="servico">IEnqueteService</param>
        public EnqueteService(IEnqueteService servico)
        {
            this._servico = servico;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção da Enquete
        /// </summary>
        /// <param name="e">Objeto Enquente para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirEnquete(Enquete e)
        {
            return await this._servico.InserirEnquete(e);
        }

        /// <summary>
        /// Método para Atualizar uma enquete
        /// </summary>
        /// <param name="e">Enquete</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarEnquete(Enquete e)
        {
            return await this._servico.AtualizarEnquete(e);
        }

        /// <summary>
        /// Método para Deletar uma enquete
        /// </summary>
        /// <param name="e">Enquete</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarEnquete(Enquete e)
        {
            return await this._servico.DeletarEnquete(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno da enquete pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da Enquete no Banco de Dados</param>
        /// <returns>Objeto Enquete</returns>
        public async Task<Enquete> RetornarEnquetePorId(int id)
        {
            return await this._servico.RetornarEnquetePorId(id);
        }

        /// <summary>
        /// Método para retorno de uma Enquete pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Enquete</returns>
        public async Task<ICollection<Enquete>> RetornarTodasEnquetes()
        {
            return await this._servico.RetornarTodasEnquetes();
        }
    }
}
