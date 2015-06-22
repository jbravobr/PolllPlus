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
    public class PerguntaService : IPerguntaService
    {

        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IPerguntaRepositorio _repositorio;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="repo">IPerguntaService</param>
        public PerguntaService(IPerguntaRepositorio repo)
        {
            this._repositorio = repo;
        }

        public async Task<Pergunta> InserirRetornarPergunta(Pergunta e)
        {
            return await this._repositorio.InserirRetornarPergunta(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção do Pergunta
        /// </summary>
        /// <param name="e">Objeto Pergunta para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirPergunta(Pergunta e)
        {
            return await this._repositorio.InserirPergunta(e);
        }

        /// <summary>
        /// Método para Atualizar um  Pergunta
        /// </summary>
        /// <param name="e">Pergunta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarPergunta(Pergunta e)
        {
            return await this._repositorio.AtualizarPergunta(e);
        }

        /// <summary>
        /// Método para Deletar um Pergunta
        /// </summary>
        /// <param name="e">Pergunta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarPergunta(Pergunta e)
        {
            return await this._repositorio.DeletarPergunta(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno do Pergunta pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da Pergunta no Banco de Dados</param>
        /// <returns>Objeto Pergunta</returns>
        public async Task<Pergunta> RetornarPerguntaPorId(int id)
        {
            return await this._repositorio.RetornarPerguntaPorId(id);
        }

        /// <summary>
        /// Método para retorno de uma Pergunta pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Pergunta</returns>
        public async Task<ICollection<Pergunta>> RetornarTodosPerguntas()
        {
            return await this._repositorio.RetornarTodasPerguntas();
        }
    }
}
