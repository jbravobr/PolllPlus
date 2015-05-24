using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;

namespace PollPlus.Service
{
    public class PlataformaService : IPlataformaService
    {
        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IPlataformaService _servico;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="servico">PlataformaService</param>
        public PlataformaService(IPlataformaService servico)
        {
            this._servico = servico;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção da Plataforma
        /// </summary>
        /// <param name="e">Objeto Plataforma para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirPlataforma(Plataforma e)
        {
            return await this._servico.InserirPlataforma(e);
        }

        /// <summary>
        /// Método para Atualizar uma  Plataforma
        /// </summary>
        /// <param name="e">Plataforma</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarPlataforma(Plataforma e)
        {
            return await this._servico.AtualizarPlataforma(e);
        }

        /// <summary>
        /// Método para Deletar uma Plataforma
        /// </summary>
        /// <param name="e">Plataforma</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarPlataforma(Plataforma e)
        {
            return await this._servico.DeletarPlataforma(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno da Plataforma pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da Empresa no Banco de Dados</param>
        /// <returns>Objeto Plataforma</returns>
        public async Task<Plataforma> RetornarPlataformaPorId(int id)
        {
            return await this._servico.RetornarPlataformaPorId(id);
        }

        /// <summary>
        /// Método para retorno de uma Plataforma pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Plataforma</returns>
        public async Task<ICollection<Plataforma>> RetornarTodasPlataformas()
        {
            return await this._servico.RetornarTodasPlataformas();
        }
    }
}
