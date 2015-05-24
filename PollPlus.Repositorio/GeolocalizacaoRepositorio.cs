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
    public class GeolocalizacaoRepositorio : BaseRepositorio<Geolocalizacao, PollPlusContext<Geolocalizacao>>, IGeolocalizacaoRepositorio
    {
        /// <summary>
        /// Método para Salvar uma Geolocalizacao
        /// </summary>
        /// <param name="e">Geolocalizacao</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirGeolocalizacao(Geolocalizacao e)
        {
            this.Inserir(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Atualizar uma Geolocalizacao
        /// </summary>
        /// <param name="e">Geolocalizacao</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>

        public async Task<bool> AtualizarGeolocalizacao(Geolocalizacao e)
        {
            this.Atualizar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para Deletar uma Geolocalizacao
        /// </summary>
        /// <param name="e">Geolocalizacao</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarGeolocalizacao(Geolocalizacao e)
        {
            this.Deletar(e);
            return await this.Salvar();
        }

        /// <summary>
        /// Método para retorno de uma Geolocalizacao pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Geolocalizacao</returns>
        public async Task<Geolocalizacao> RetornarGeolocalizacaoPorId(int id)
        {
            Expression<Func<Geolocalizacao, bool>> porId = (x) => x.Id == id;
            return await this.RetornarPorId(porId);
        }

        /// <summary>
        /// Método para retorno de uma Geolocalizacao pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Geolocalizacao</returns>
        public async Task<ICollection<Geolocalizacao>> RetornarTodasGeolocalizacoes()
        {
            return await this.RetornarTodos();
        }
    }
}
