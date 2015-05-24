using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;

namespace PollPlus.Service
{
    public class MensagemService : IMensagemService
    {

        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IMensagemService _servico;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="servico">IMensagemService</param>
        public MensagemService(IMensagemService servico)
        {
            this._servico = servico;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção da Mensagem
        /// </summary>
        /// <param name="e">Objeto Mensagem para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirMensagem(Mensagem e)
        {
            return await this._servico.InserirMensagem(e);
        }

        /// <summary>
        /// Método para Atualizar uma Mensagem
        /// </summary>
        /// <param name="e">Mensagem</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarMensagem(Mensagem e)
        {
            return await this._servico.AtualizarMensagem(e);
        }

        /// <summary>
        /// Método para Deletar uma Mensagem
        /// </summary>
        /// <param name="e">Mensagem</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarMensagem(Mensagem e)
        {
            return await this._servico.DeletarMensagem(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno da Mensagem pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da Mensagem no Banco de Dados</param>
        /// <returns>Objeto Mensagem</returns>
        public async Task<Mensagem> RetornarMensagemPorId(int id)
        {
            return await this._servico.RetornarMensagemPorId(id);
        }

        /// <summary>
        /// Método para retorno de uma Mensagem pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Mensagem</returns>
        public async Task<ICollection<Mensagem>> RetornarTodasMensagens()
        {
            return await this._servico.RetornarTodasMensagens();
        }
    }
}
