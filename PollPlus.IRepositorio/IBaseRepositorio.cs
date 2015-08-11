using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IBaseRepositorio<T>
    {
        void Inserir(T entidade);
        void Deletar(T entidade);
        Task<ICollection<T>> ProcurarPorColecao(Expression<Func<T, bool>> predicado);
        Task<ICollection<T>> RetornarTodos();
        Task<T> ProcurarPorFiltro(Expression<Func<T, bool>> predicado);
        Task<T> RetornarPorId(Expression<Func<T, bool>> predicado);
        void Atualizar(T entidade);
        Task<bool> Salvar();
        Task<bool> SalvarEAguardar(TimeSpan tempoTotalParaRodar);
    }
}
