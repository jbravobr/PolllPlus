using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Transactions;

using PollPlus.IRepositorio;

namespace PollPlus.Repositorio
{
    public abstract class BaseRepositorio<T, C> : IBaseRepositorio<T>
        where T : class
        where C : DbContext, new()
    {
        private C _entidades = new C();
        public C Context
        {
            get { return _entidades; }
            set { _entidades = value; }
        }

        /// <summary>
        /// Insere uma nova entidade T no Banco de Dados
        /// </summary>
        public void Inserir(T entity)
        {
            try
            {
                _entidades.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete uma determinada entidade T do Banco de Dados
        /// </summary>
        public void Deletar(T entity)
        {
            _entidades.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Retorna uma coleção de Entidades T de acordo com um predicado
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<T>> ProcurarPorColecao(Expression<Func<T, bool>> predicado)
        {
            return await _entidades.Set<T>().Where(predicado).ToListAsync();
        }

        public async Task<T> ProcurarPorFiltro(Expression<Func<T, bool>> predicado)
        {
            return await _entidades.Set<T>().Where(predicado).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Retorna um único registro da entidade T
        /// </summary>
        /// <param name="entity">Entidade</param>
        /// <param name="predicate">Predicado para execução do filtro (deve-ser usar a busca por ID)</param>
        /// <returns></returns>
        public async Task<T> RetornarPorId(Expression<Func<T, bool>> predicado)
        {
            return await _entidades.Set<T>().FirstAsync(predicado);
        }

        /// <summary>
        /// Retorna todas as Entidades T
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<T>> RetornarTodos()
        {
            return await _entidades.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Atualizar uma Entidade T
        /// </summary>
        /// <param name="entity"></param>
        public void Atualizar(T entidade)
        {
            try
            {
                _entidades.Entry(entidade).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Salva as modificações do contexto em memória para o Banco de Dados
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Salvar()
        {
            try
            {
                return await Context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inserir as modificações em memória para o Banco de Dados e retornar a entidade inserida
        /// </summary>
        /// <returns></returns>
        public async Task<T> InsertAndReturnEntity(T entity)
        {
            try
            {
                _entidades.Set<T>().Add(entity);
                await Context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao inserir entidade ao contexto.");
            }
        }

        /// <summary>
        /// Salva as modificações que necessitam de um tempo maior para rodar
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SalvarEAguardar(TimeSpan tempoTotalParaRodar)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await this.Context.SaveChangesAsync();
                    scope.Complete();
                    return true;
                }
                catch
                {
                }

                return false;
            }
        }
    }
}
