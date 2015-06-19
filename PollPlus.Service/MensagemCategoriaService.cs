using PollPlus.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using System.Linq.Expressions;
using PollPlus.IService;

namespace PollPlus.Service
{
    public class MensagemCategoriaService : IMensagemCategoriaService
    {
        readonly IMensagemCategoriaRepositorio _repositorio;

        public MensagemCategoriaService(IMensagemCategoriaRepositorio repo)
        {
            this._repositorio = repo;
        }

        public async Task<bool> InserirMensagemCategoria(MensagemCategoria ec)
        {
            return await this._repositorio.InserirMensagemCategoria(ec);
        }

        public async Task<bool> RemoverMensagemCategoria(int id)
        {
            return await this._repositorio.RemoverMensagemCategoria(id);
        }

        public async Task<ICollection<MensagemCategoria>> RetornarMensagemCategoriaPorMensagem(int mensagemId)
        {
            return await this._repositorio.RetornarMensagemCategoriaPorMensagem(mensagemId);
        }

        public async Task<ICollection<MensagemCategoria>> RetornarMensagemCategoriaPorCategoria(int categoriaId)
        {
            return await this._repositorio.RetornarMensagemCategoriaPorCategoria(categoriaId);
        }

        public async Task<ICollection<MensagemCategoria>> RetornarMensagemCategoriaTodos()
        {
            return await this._repositorio.RetornarMensagemCategoriaTodos();
        }
    }
}
