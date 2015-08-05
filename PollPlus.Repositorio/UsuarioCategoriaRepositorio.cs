using PollPlus.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.Repositorio.EFContext;
using System.Linq.Expressions;

namespace PollPlus.Repositorio
{
    public class UsuarioCategoriaRepositorio : BaseRepositorio<UsuarioCategoria, PollPlusContext<UsuarioCategoria>>, IUsuarioCategoriaRepositorio
    {
        /// <summary>
        /// Insere uma nova associação entre Usuário e Categoria
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        public async Task<bool> InserirUsuarioCategoria(UsuarioCategoria uc)
        {
            base.Inserir(uc);
            return await base.Salvar();
        }

        /// <summary>
        /// Remove uma associação entre Usuário e Categoria
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        public async Task<bool> RemoverUsuarioCategoria(int Id)
        {
            Expression<Func<UsuarioCategoria, bool>> porId = (x) => x.Id == Id;
            var entity = await base.RetornarPorId(porId);

            base.Deletar(entity);

            return await Task.FromResult<bool>(true);
        }

        /// <summary>
        /// Retornar uma associação entre Usuário e Categoria baseado em uma Categoria
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        public async Task<ICollection<UsuarioCategoria>> RetornarUsuarioCategoriaPorCategoria(int CategoriaId)
        {
            Expression<Func<UsuarioCategoria, bool>> filtro = (x) => x.CategoriaId == CategoriaId;
            return await base.ProcurarPorColecao(filtro);
        }

        /// <summary>
        /// Retornar uma associação entre Usuário e Categoria baseado em uma lista de Categorias
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        public async Task<ICollection<UsuarioCategoria>> RetornarUsuarioCategoriaPorCategorias(ICollection<int> CategoriasId)
        {
            Expression<Func<UsuarioCategoria, bool>> filtro = (x) => CategoriasId.Contains(x.CategoriaId);
            return await base.ProcurarPorColecao(filtro);
        }

        /// <summary>
        /// Retornar uma associação entre Usuário e Categoria baseado em um Usuário
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        public async Task<ICollection<UsuarioCategoria>> RetornarUsuarioCategoriaPorUsuario(int UsuarioId)
        {
            Expression<Func<UsuarioCategoria, bool>> filtro = (x) => x.UsuarioId == UsuarioId;
            return await base.ProcurarPorColecao(filtro);
        }

        public async Task DeletarCategoriasDoUsuario(int UsuarioId)
        {
            var remover = await this.RetornarUsuarioCategoriaPorUsuario(UsuarioId);

            foreach (var item in remover)
            {
                base.Deletar(item);
                await base.Salvar();
            }
        }
    }
}
