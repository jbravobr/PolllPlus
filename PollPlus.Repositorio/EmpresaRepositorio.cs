using PollPlus.Domain;
using PollPlus.IRepositorio;
using PollPlus.Repositorio.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Repositorio
{
    public class EmpresaRepositorio : BaseRepositorio<Empresa, PollPlusContext<Empresa>>, IEmpresaRepositorio
    {
        /// <summary>
        /// Método para Salvar uma Empresa
        /// </summary>
        /// <param name="e">Empresa</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirEmpresa(Empresa e)
        {
            this.Inserir(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Atualizar uma Empresa
        /// </summary>
        /// <param name="e">Empresa</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>

        public async Task<bool> AtualizarEmpresa(Empresa e)
        {
            this.Atualizar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Deletar uma Empresa
        /// </summary>
        /// <param name="e">Empresa</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarEmpresa(Empresa e)
        {
            this.Deletar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma Empresa pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Empresa</returns>
        public async Task<Empresa> RetornarEmpresaPorId(int id)
        {
            Expression<Func<Empresa, bool>> porId = (x) => x.Id == id;
            return await this.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma Empresa pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Empresa</returns>
        public async Task<ICollection<Empresa>> RetornarTodasEmpresas()
        {
            return await this.RetornarTodos();
        }
    }
}
