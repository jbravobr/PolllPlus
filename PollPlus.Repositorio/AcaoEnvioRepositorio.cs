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
    public class AcaoRepositorioRepositorio : BaseRepositorio<AcaoEnvio, PollPlusContext<AcaoEnvio>>
    {
        /// <summary>
        /// Método para Salvar uma AcaoEnvio
        /// </summary>
        /// <param name="e">AcaoEnvio</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirAcaoEnvio(AcaoEnvio e)
        {
            base.Inserir(e);
            return await base.Salvar();
        }

        public async Task<AcaoEnvio> InserirRetornarAcaoEnvio(AcaoEnvio e)
        {
            return await base.InsertAndReturnEntity(e);
        }

        public async Task<bool> AtualizarAcaoEnvio(AcaoEnvio e)
        {
            base.Atualizar(e);
            return await base.Salvar();
        }

        /// <summary>
        /// Método para Deletar uma AcaoEnvio
        /// </summary>
        /// <param name="e">AcaoEnvio</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarAcaoEnvio(AcaoEnvio e)
        {
            base.Deletar(e);
            return await base.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma AcaoEnvio pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto AcaoEnvio</returns>
        public async Task<AcaoEnvio> RetornarAcaoEnvioPorId(int id)
        {
            Expression<Func<AcaoEnvio, bool>> porId = (x) => x.Id == id;
            return await base.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma AcaoEnvio pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto AcaoEnvio</returns>
        public async Task<ICollection<AcaoEnvio>> RetornarTodosAcaoEnvios()
        {
            return await base.RetornarTodos();
        }
    }
}
