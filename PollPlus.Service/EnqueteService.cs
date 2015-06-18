using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IRepositorio;

namespace PollPlus.Service
{
    public class EnqueteService : IEnqueteService
    {
        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IEnqueteRepositorio _repositorio;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="repo">IEnqueteService</param>
        public EnqueteService(IEnqueteRepositorio repo)
        {
            this._repositorio = repo;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção da Enquete
        /// </summary>
        /// <param name="e">Objeto Enquente para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirEnquete(Enquete e)
        {
            return await this._repositorio.InserirEnquete(e);
        }

        /// <summary>
        /// Método para Atualizar uma enquete
        /// </summary>
        /// <param name="e">Enquete</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarEnquete(Enquete e)
        {
            return await this._repositorio.AtualizarEnquete(e);
        }

        /// <summary>
        /// Método para Deletar uma enquete
        /// </summary>
        /// <param name="e">Enquete</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarEnquete(Enquete e)
        {
            return await this._repositorio.DeletarEnquete(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno da enquete pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da Enquete no Banco de Dados</param>
        /// <returns>Objeto Enquete</returns>
        public async Task<Enquete> RetornarEnquetePorId(int id)
        {
            return await this._repositorio.RetornarEnquetePorId(id);
        }

        /// <summary>
        /// Método para retorno de uma Enquete pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Enquete</returns>
        public async Task<ICollection<Enquete>> RetornarTodasEnquetes()
        {
            return await this._repositorio.RetornarTodasEnquetes();
        }
    }
}
