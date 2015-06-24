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
    public class BannerRepositorio : BaseRepositorio<Banner, PollPlusContext<Banner>>, IBannerRepositorio
    {
        /// <summary>
        /// Método para Salvar uma Banner
        /// </summary>
        /// <param name="e">Banner</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirBanner(Banner e)
        {
            base.Inserir(e);
            return await base.Salvar();
        }

        /// <summary>
        /// Método para Deletar uma Banner
        /// </summary>
        /// <param name="e">Banner</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarBanner(Banner e)
        {
            base.Deletar(e);
            return await base.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma Banner pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Banner</returns>
        public async Task<Banner> RetornarBannerPorId(int id)
        {
            Expression<Func<Banner, bool>> porId = (x) => x.Id == id;
            return await base.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma Banner pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Banner</returns>
        public async Task<ICollection<Banner>> RetornarTodosBanners()
        {
            return await base.RetornarTodos();
        }

        public async Task<ICollection<Banner>> RetornarBannerPorEmpresaId(int empresaId)
        {
            Expression<Func<Banner, bool>> porEmpresaId = (x) => x.EmpresaId == empresaId;
            return (await base.RetornarTodos());
        }
    }
}
