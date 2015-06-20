using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IService;

namespace PollPlus.Service
{
    public class PerguntaServiceWEB : IPerguntaServiceWEB
    {
        readonly IPerguntaService _service;

        public PerguntaServiceWEB(IPerguntaService service)
        {
            this._service = service;
        }

        public async Task<Pergunta> InserirRetornarPergunta(Pergunta r)
        {
            return await this._service.InserirRetornarPergunta(r);
        }

        public async Task<bool> AtualizarPergunta(Pergunta e)
        {
            return await this._service.AtualizarPergunta(e);
        }

        public async Task<bool> DeletarPergunta(Pergunta e)
        {
            return await this._service.DeletarPergunta(e);
        }

        public async Task<bool> InserirPergunta(Pergunta e)
        {
            return await this._service.InserirPergunta(e);
        }

        public async Task<Pergunta> RetornarPerguntaPorId(int id)
        {
            return await this._service.RetornarPerguntaPorId(id);
        }

        public async Task<ICollection<Pergunta>> RetornarTodosPerguntas()
        {
            return await this._service.RetornarTodosPerguntas();
        }
    }
}
