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
    public class CategoriaService : ICategoriaService
    {

        /// <summary>
        /// Propriedade de exposição para a injeção de dependência
        /// </summary>
        readonly ICategoriaRepositorio _repositorio;

        /// <summary>
        /// Construtor parametrizado com a injeção de dependência
        /// </summary>
        /// <param name="repositorio">IEnqueteService</param>
        public CategoriaService(ICategoriaRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        /// <summary>
        /// Realiza a chamada ao repositório para inserção da Categoria
        /// </summary>
        /// <param name="e">Objeto Categoria para nova inserção</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> InserirCategoria(Categoria e)
        {
            return await this._repositorio.InserirCategoria(e);
        }

        /// <summary>
        /// Método para Atualizar uma Categoria
        /// </summary>
        /// <param name="e">Categoria</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> AtualizarCategoria(Categoria e)
        {
            return await this._repositorio.AtualizarCategoria(e);
        }

        /// <summary>
        /// Método para Deletar uma Categoria
        /// </summary>
        /// <param name="e">Categoria</param>
        /// <returns>Verdadeiro ou falso para a inserção</returns>
        public async Task<bool> DeletarCategoria(Categoria e)
        {
            return await this._repositorio.DeletarCategoria(e);
        }

        /// <summary>
        /// Realiza a chamada ao repositório para retorno da categoria pelo seu ID
        /// </summary>
        /// <param name="id">Identificação da Categoria no Banco de Dados</param>
        /// <returns>Objeto Categoria</returns>
        public async Task<Categoria> RetornarCategoriaPorId(int id)
        {
            return await this._repositorio.RetornarCategoriaPorId(id);
        }

        /// <summary>
        /// Método para retorno de uma Categoria pelo seu identificador no Banco de Dados
        /// </summary>
        /// <param name="id">Identificador do registro no Banco de Dados</param>
        /// <returns>Objeto Categoria</returns>
        public async Task<ICollection<Categoria>> RetornarTodasCategorias()
        {
            return await this._repositorio.RetornarTodasCategorias();
        }
    }
}
