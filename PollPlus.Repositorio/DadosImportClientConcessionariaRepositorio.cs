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
    public class DadosImportClientConcessionariaRepositorio : BaseRepositorio<DadosImportClientConcessionaria, PollPlusContext<DadosImportClientConcessionaria>>
    {
        /// <summary>
        /// Método para Salvar uma Banner
        /// </summary>
        /// <param name="e">Banner</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirImporClientConcessionaria(DadosImportClientConcessionaria e)
        {
            base.Inserir(e);
            return await base.Salvar();
        }

        public async Task<DadosImportClientConcessionaria> InserirRetornarImporClientConcessionaria(DadosImportClientConcessionaria e)
        {
            return await base.InsertAndReturnEntity(e);
        }

        public async Task<bool> AtualizarImporClientConcessionaria(DadosImportClientConcessionaria e)
        {
            base.Atualizar(e);
            return await base.Salvar();
        }

        /// <summary>
        /// Método para Deletar uma Banner
        /// </summary>
        /// <param name="e">Banner</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarImporClientConcessionaria(DadosImportClientConcessionaria e)
        {
            base.Deletar(e);
            return await base.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma Banner pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Banner</returns>
        public async Task<DadosImportClientConcessionaria> RetornarImporClientConcessionariaPorId(int id)
        {
            Expression<Func<DadosImportClientConcessionaria, bool>> porId = (x) => x.Id == id;
            return await base.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma Banner pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Banner</returns>
        public async Task<ICollection<DadosImportClientConcessionaria>> RetornarTodosImporClientConcessionaria()
        {
            return await base.RetornarTodos();
        }

        public async Task<ICollection<DadosImportClientConcessionaria>> RetornarImporClientConcessionariaPorModeloId(string modelo)
        {
            Expression<Func<DadosImportClientConcessionaria, bool>> porEmpresaId = (x) => x.Modelo.Equals(modelo);
            return (await base.RetornarTodos());
        }
    }
}
