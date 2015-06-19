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
    public class PerguntaRespostaService : IPerguntaRespostaService
    {
        readonly IPerguntaRespostaRepositorio _repositorio;

        public PerguntaRespostaService(IPerguntaRespostaRepositorio repo)
        {
            this._repositorio = repo;
        }

        public async Task<bool> AtualizarPerguntaResposta(PerguntaResposta pr)
        {
            return await this._repositorio.AtualizarPerguntaResposta(pr);

        }

        public async Task<bool> InserirPerguntaResposta(PerguntaResposta ec)
        {
            return await this._repositorio.InserirPerguntaResposta(ec);

        }

        public async Task<bool> RemoverPerguntaResposta(int id)
        {
            return await this._repositorio.RemoverPerguntaResposta(id);
        }

        public async Task<ICollection<PerguntaResposta>> RetornarPerguntaRespostaPorPergunta(int perguntaId)
        {
            return await this._repositorio.RetornarPerguntaRespostaPorPergunta(perguntaId);
        }

        public async Task<ICollection<PerguntaResposta>> RetornarPerguntaRespostaPorResposta(int respostaId)
        {
            return await this._repositorio.RetornarPerguntaRespostaPorResposta(respostaId);
        }

        public async Task<ICollection<PerguntaResposta>> RetornarPerguntaRespostaTodos()
        {
            return await this._repositorio.RetornarPerguntaRespostaTodos();
        }
    }
}
