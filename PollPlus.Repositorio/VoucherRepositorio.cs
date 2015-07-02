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
    public class VoucherRepositorio : BaseRepositorio<Voucher, PollPlusContext<Voucher>>, IVoucherRepositorio
    {
        /// <summary>
        /// Método para Salvar um VoucherVoucher
        /// </summary>
        /// <param name="e">Voucher</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirVoucher(Voucher e)
        {
            this.Inserir(e);
            return await base.Salvar();
        }

        /// <summary>
        /// Método para Atualizar um Voucher
        /// </summary>
        /// <param name="e">Voucher</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>

        public async Task<bool> AtualizarVoucher(Voucher e)
        {
            this.Atualizar(e);
            return await base.Salvar();
        }

        /// <summary>
        /// Método para Deletar um Voucher
        /// </summary>
        /// <param name="e">Voucher</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarVoucher(Voucher e)
        {
            this.Deletar(e);
            return await base.Salvar();
        }

        /// <summary>
        /// Método para retorno de um Voucher pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Voucher</returns>
        public async Task<Voucher> RetornarVoucherPorId(int id)
        {
            Expression<Func<Voucher, bool>> porId = (x) => x.Id == id;
            return await base.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma Voucher pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Voucher</returns>
        public async Task<ICollection<Voucher>> RetornarTodosVouchers()
        {
            return await base.RetornarTodos();
        }

        public async Task<Voucher> InserirRetornarVoucher(Voucher e)
        {
            return await base.InsertAndReturnEntity(e);
        }
    }
}
