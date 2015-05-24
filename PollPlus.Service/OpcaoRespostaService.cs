using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;

namespace PollPlus.Service
{
    public class OpcaoRespostaService : IOpcaoRespostaService
    {

        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IOpcaoRespostaService _servico;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="servico">IOpcaoRespostaService</param>
        public OpcaoRespostaService(IOpcaoRespostaService servico)
        {
            this._servico = servico;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção da OpcaoRespostaService
        /// </summary>
        /// <param name="e">Objeto OpcaoRespostaService para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirOpcaoResposta(OpcaoResposta e)
        {
            return await this._servico.InserirOpcaoResposta(e);
        }

        /// <summary>
        /// Método para Atualizar uma OpcaoResposta
        /// </summary>
        /// <param name="e">OpcaoResposta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarOpcaoResposta(OpcaoResposta e)
        {
            return await this._servico.AtualizarOpcaoResposta(e);
        }

        /// <summary>
        /// Método para Deletar uma OpcaoResposta
        /// </summary>
        /// <param name="e">OpcaoResposta</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarOpcaoResposta(OpcaoResposta e)
        {
            return await this._servico.DeletarOpcaoResposta(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno da OpcaoResposta pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da OpcaoEnquete no Banco de Dados</param>
        /// <returns>Objeto OpcaoResposta</returns>
        public async Task<OpcaoResposta> RetornarOpcaoRespostaPorId(int id)
        {
            return await this._servico.RetornarOpcaoRespostaPorId(id);
        }

        /// <summary>
        /// Método para retorno de uma OpcaoEnquete pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto OpcaoEnquete</returns>
        public async Task<ICollection<OpcaoResposta>> RetornarTodasOpcoesRespostas()
        {
            return await this._servico.RetornarTodasOpcoesRespostas();
        }
    }
}
