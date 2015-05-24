using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;

namespace PollPlus.Service
{
    public class GeolocalizacaoService : IGeolocalizacaoService
    {

        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IGeolocalizacaoService _servico;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="servico">IGeolocalizacaoService</param>
        public GeolocalizacaoService(IGeolocalizacaoService servico)
        {
            this._servico = servico;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção da  Geolocalizacao 
        /// </summary>
        /// <param name="e">Objeto Empresa para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirGeolocalizacao(Geolocalizacao e)
        {
            return await this._servico.InserirGeolocalizacao(e);
        }

        /// <summary>
        /// Método para Atualizar uma  Geolocalizacao
        /// </summary>
        /// <param name="e">Geolocalizacao</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarGeolocalizacao(Geolocalizacao e)
        {
            return await this._servico.AtualizarGeolocalizacao(e);
        }

        /// <summary>
        /// Método para Deletar uma Geolocalizacao
        /// </summary>
        /// <param name="e">Geolocalizacao</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarGeolocalizacao(Geolocalizacao e)
        {
            return await this._servico.DeletarGeolocalizacao(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno da Geolocalizacao pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da Geolocalizacao no Banco de Dados</param>
        /// <returns>Objeto Geolocalizacao</returns>
        public async Task<Geolocalizacao> RetornarGeolocalizacaoPorId(int id)
        {
            return await this._servico.RetornarGeolocalizacaoPorId(id);
        }

        /// <summary>
        /// Método para retorno de uma Geolocalizacao pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Geolocalizacao</returns>
        public async Task<ICollection<Geolocalizacao>> RetornarTodasGeolocalizacoes()
        {
            return await this._servico.RetornarTodasGeolocalizacoes();
        }
    }
}
