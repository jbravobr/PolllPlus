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
    public class RespostaImagemRepositorio : BaseRepositorio<RespostaImagem, PollPlusContext<RespostaImagem>>
    {
        /// <summary>
        /// Método para Salvar uma Banner
        /// </summary>
        /// <param name="e">Banner</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirRespostaImagem(RespostaImagem e)
        {
            base.Inserir(e);
            return await base.Salvar();
        }

        public async Task<RespostaImagem> InserirRetornarRespostaImagem(RespostaImagem e)
        {
            return await base.InsertAndReturnEntity(e);
        }

        public async Task<bool> AtualizarRespostaImagem(RespostaImagem e)
        {
            base.Atualizar(e);
            return await base.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma Banner pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Banner</returns>
        public async Task<RespostaImagem> RetornarRepostaImagemPorRespostaId(int id)
        {
            Expression<Func<RespostaImagem, bool>> porId = (x) => x.RespostaId == id;
            return await base.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma Banner pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Banner</returns>
        public async Task<ICollection<RespostaImagem>> RetornarTodasRespostasImagem()
        {
            return await base.RetornarTodos();
        }
    }
}
