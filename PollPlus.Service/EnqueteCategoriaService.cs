using PollPlus.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using System.Linq.Expressions;

namespace PollPlus.Repositorio
{
    public class EnqueteCategoriaService : IEnqueteCategoriaService
    {
        readonly IEnqueteCategoriaRepositorio _repositorio;

        public EnqueteCategoriaService(IEnqueteCategoriaRepositorio repo)
        {
            this._repositorio = repo;
        }

        public async Task<bool> InserirEnqueteCategoria(EnqueteCategoria ec)
        {
            return await this._repositorio.InserirEnqueteCategoria(ec);
        }

        public async Task<bool> RemoverEnqueteCategoria(int id)
        {
            return await this._repositorio.RemoverEnqueteCategoria(id);
        }

        public async Task<ICollection<EnqueteCategoria>> RetornarEnqueteCategoriaCategoria(int categoriaId)
        {
            return await this._repositorio.RetornarEnqueteCategoriaCategoria(categoriaId);
        }

        public async Task<ICollection<EnqueteCategoria>> RetornarEnqueteCategoriaEnquete(int enqueteId)
        {
            return await this._repositorio.RetornarEnqueteCategoriaEnquete(enqueteId);
        }

        public async Task<ICollection<EnqueteCategoria>> RetornarEnqueteCategoriaTodos()
        {
            return await this._repositorio.RetornarEnqueteCategoriaTodos();
        }
    }
}
