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
    public class CategoriaRepositorio : BaseRepositorio<Categoria, PollPlusContext<Categoria>>, ICategoriaRepositorio
    {
        /// <summary>
        /// Método para Salvar uma categoria
        /// </summary>
        /// <param name="e">Categoria</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirCategoria(Categoria e)
        {
            this.Inserir(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Atualizar uma categoria
        /// </summary>
        /// <param name="e">Categoria</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>

        public async Task<bool> AtualizarCategoria(Categoria e)
        {
            this.Atualizar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Deletar uma categoria
        /// </summary>
        /// <param name="e">Categoria</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarCategoria(Categoria e)
        {
            this.Deletar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma categoria pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Categoria</returns>
        public async Task<Categoria> RetornarCategoriaPorId(int id)
        {
            Expression<Func<Categoria, bool>> porId = (x) => x.Id == id;
            return await this.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma Categoria pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Categoria</returns>
        public async Task<ICollection<Categoria>> RetornarTodasCategorias()
        {
            return await this.RetornarTodos();
        }
    }
}
