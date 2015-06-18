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
    public class EmpresaService : IEmpresaService
    {

        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IEmpresaRepositorio _repositorio;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="repo">IEmpresaService</param>
        public EmpresaService(IEmpresaRepositorio repo)
        {
            this._repositorio = repo;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção da Empresa
        /// </summary>
        /// <param name="e">Objeto Empresa para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirEmpresa(Empresa e)
        {
            return await this._repositorio.InserirEmpresa(e);
        }

        /// <summary>
        /// Método para Atualizar uma Empresa
        /// </summary>
        /// <param name="e">Empresa</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarEmpresa(Empresa e)
        {
            return await this._repositorio.AtualizarEmpresa(e);
        }

        /// <summary>
        /// Método para Deletar uma Empresa
        /// </summary>
        /// <param name="e">Empresa</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarEmpresa(Empresa e)
        {
            return await this._repositorio.DeletarEmpresa(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno da empresa pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da Empresa no Banco de Dados</param>
        /// <returns>Objeto Empresa</returns>
        public async Task<Empresa> RetornarEmpresaPorId(int id)
        {
            return await this._repositorio.RetornarEmpresaPorId(id);
        }

        /// <summary>
        /// Método para retorno de uma Empresa pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Empresa</returns>
        public async Task<ICollection<Empresa>> RetornarTodasEmpresas()
        {
            return await this._repositorio.RetornarTodasEmpresas();
        }
    }
}
