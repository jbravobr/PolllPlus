using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;

namespace PollPlus.Service
{
    public class EmpresaService : IEmpresaService
    {

        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IEmpresaService _servico;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="servico">IEmpresaService</param>
        public EmpresaService(IEmpresaService servico)
        {
            this._servico = servico;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção da Empresa
        /// </summary>
        /// <param name="e">Objeto Empresa para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirEmpresa(Empresa e)
        {
            return await this._servico.InserirEmpresa(e);
        }

        /// <summary>
        /// Método para Atualizar uma Empresa
        /// </summary>
        /// <param name="e">Empresa</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarEmpresa(Empresa e)
        {
            return await this._servico.AtualizarEmpresa(e);
        }

        /// <summary>
        /// Método para Deletar uma Empresa
        /// </summary>
        /// <param name="e">Empresa</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarEmpresa(Empresa e)
        {
            return await this._servico.DeletarEmpresa(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno da empresa pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da Empresa no Banco de Dados</param>
        /// <returns>Objeto Empresa</returns>
        public async Task<Empresa> RetornarEmpresaPorId(int id)
        {
            return await this._servico.RetornarEmpresaPorId(id);
        }

        /// <summary>
        /// Método para retorno de uma Empresa pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Empresa</returns>
        public async Task<ICollection<Empresa>> RetornarTodasEmpresas()
        {
            return await this._servico.RetornarTodasEmpresas();
        }
    }
}
