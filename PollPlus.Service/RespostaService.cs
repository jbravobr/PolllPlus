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
    public class RespostaService : IRespostaService
    {

        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IRespostaRepositorio _repositorio;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="repo">IRespostaService</param>
        public RespostaService(IRespostaRepositorio repo)
        {
            this._repositorio = repo;
        }

        public async Task<Resposta> InserirRetornarResposta(Resposta e)
        {
            return await this._repositorio.InserirRetornarResposta(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção do Resposta
        /// </summary>
        /// <param name="e">Objeto Resposta para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirResposta(Resposta e)
        {
            return await this._repositorio.InserirResposta(e);
        }

        /// <summary>
        /// Método para Atualizar um  Resposta
        /// </summary>
        /// <param name="e">Resposta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarResposta(Resposta e)
        {
            return await this._repositorio.AtualizarResposta(e);
        }

        /// <summary>
        /// Método para Deletar um Resposta
        /// </summary>
        /// <param name="e">Resposta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarResposta(Resposta e)
        {
            return await this._repositorio.DeletarResposta(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno do Resposta pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da Resposta no Banco de Dados</param>
        /// <returns>Objeto Resposta</returns>
        public async Task<Resposta> RetornarRespostaPorId(int id)
        {
            return await this._repositorio.RetornarRespostaPorId(id);
        }

        /// <summary>
        /// Método para retorno de uma Resposta pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Resposta</returns>
        public async Task<ICollection<Resposta>> RetornarTodosRespostas()
        {
            return await this._repositorio.RetornarTodasRespostas();
        }
    }
}
