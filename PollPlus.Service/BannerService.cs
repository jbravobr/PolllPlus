using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IRepositorio;

namespace PollPlus.Service
{
    public class BannerService : IBannerService
    {

        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly IBannerRepositorio _repositorio;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="repositorio">IEnqueteService</param>
        public BannerService(IBannerRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção da Banner
        /// </summary>
        /// <param name="e">Objeto Banner para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirBanner(Banner e)
        {
            return await this._repositorio.InserirBanner(e);
        }

        public async Task<Banner> InserirRetornarBanner(Banner e)
        {
            return await this._repositorio.InserirRetornarBanner(e);
        }

        /// <summary>
        /// Método para Deletar uma Banner
        /// </summary>
        /// <param name="e">Banner</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarBanner(Banner e)
        {
            return await this._repositorio.DeletarBanner(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno da Banner pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da Banner no Banco de Dados</param>
        /// <returns>Objeto Banner</returns>
        public async Task<Banner> RetornarBannerPorId(int id)
        {
            return await this._repositorio.RetornarBannerPorId(id);
        }

        /// <summary>
        /// Método para retorno de uma Banner pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Banner</returns>
        public async Task<ICollection<Banner>> RetornarTodosBanners()
        {
            return await this._repositorio.RetornarTodosBanners();
        }

        public async Task<ICollection<Banner>> RetornarBannerPorEmpresaId(int empresaId)
        {
            return await this._repositorio.RetornarBannerPorEmpresaId(empresaId);
        }
    }
}
