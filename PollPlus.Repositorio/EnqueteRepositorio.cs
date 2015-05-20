using PollPlus.Domain;
using PollPlus.IRepositorio;
using PollPlus.Repositorio.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Repositorio
{
    public class EnqueteRepositorio : BaseRepositorio<Enquete, PollPlusContext<Enquete>>, IEnqueteRepositorio
    {
        /// <summary>
        /// Método para Salvar uma enquete
        /// </summary>
        /// <param name="e">Enquete</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirEnquete(Enquete e)
        {
            this.Inserir(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma Enquete pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Enquete</returns>
        public async Task<Enquete> RetornarEnquenetePorId(int id)
        {
            return await this.RetornarEnquenetePorId(id);
        }
    }
}
