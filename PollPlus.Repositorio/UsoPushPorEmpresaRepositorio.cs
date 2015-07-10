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
    public class UsoPushPorEmpresaRepositorio : BaseRepositorio<UsoPushPorEmpresa, PollPlusContext<UsoPushPorEmpresa>>, IUsoPushPorEmpresaRepositorio
    {
        /// <summary>
        /// Método para Salvar uma Banner
        /// </summary>
        /// <param name="e">Banner</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirUsoPushPorEmpresa(UsoPushPorEmpresa e)
        {
            base.Inserir(e);
            return await base.Salvar();
        }

        public async Task<UsoPushPorEmpresa> InserirRetornarUsoPushPorEmpresa(UsoPushPorEmpresa e)
        {
            return await base.InsertAndReturnEntity(e);
        }

        public async Task<bool> AtualizarUsoPushPorEmpresa(UsoPushPorEmpresa e)
        {
            base.Atualizar(e);
            return await base.Salvar();
        }

        /// <summary>
        /// Método para Deletar uma Banner
        /// </summary>
        /// <param name="e">Banner</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarUsoPushPorEmpresa(UsoPushPorEmpresa e)
        {
            base.Deletar(e);
            return await base.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma Banner pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Banner</returns>
        public async Task<UsoPushPorEmpresa> RetornarUsoPushPorEmpresaPorId(int id)
        {
            Expression<Func<UsoPushPorEmpresa, bool>> porId = (x) => x.Id == id;
            return await base.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma Banner pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Banner</returns>
        public async Task<ICollection<UsoPushPorEmpresa>> RetornarTodosUsoPushPorEmpresa()
        {
            return await base.RetornarTodos();
        }
    }
}
