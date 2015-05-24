﻿using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;


namespace PollPlus.Service
{
    public class VoucherService : IVoucherService
    {

        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IVoucherService _servico;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="servico">IVoucherService</param>
        public VoucherService(IVoucherService servico)
        {
            this._servico = servico;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção do Voucher 
        /// </summary>
        /// <param name="e">Objeto Voucher para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirVoucher(Voucher e)
        {
            return await this._servico.InserirVoucher(e);
        }

        /// <summary>
        /// Método para Atualizar um  Voucher
        /// </summary>
        /// <param name="e">Voucher</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarVoucher(Voucher e)
        {
            return await this._servico.AtualizarVoucher(e);
        }

        /// <summary>
        /// Método para Deletar um Voucher
        /// </summary>
        /// <param name="e">Voucher</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarVoucher(Voucher e)
        {
            return await this._servico.DeletarVoucher(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno do Voucher pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da Voucher no Banco de Dados</param>
        /// <returns>Objeto Voucher</returns>
        public async Task<Voucher> RetornarVoucherPorId(int id)
        {
            return await this._servico.RetornarVoucherPorId(id);
        }

        /// <summary>
        /// Método para retorno de uma Voucher pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Voucher</returns>
        public async Task<ICollection<Voucher>> RetornarTodosVouchers()
        {
            return await this._servico.RetornarTodosVouchers();
        }
    }
}
