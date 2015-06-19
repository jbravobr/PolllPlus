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
    public class PerguntaRespostaServiceWEB : IPerguntaRespostaServiceWEB
    {
        readonly IPerguntaRespostaService service;

        public PerguntaRespostaServiceWEB(IPerguntaRespostaService _service)
        {
            this.service = _service;
        }

        public async Task<bool> AtualizarPerguntaResposta(PerguntaResposta pr)
        {
            return await this.service.AtualizarPerguntaResposta(pr);
        }

        public async Task<bool> InserirPerguntaResposta(PerguntaResposta pr)
        {
            return await this.service.InserirPerguntaResposta(pr);
        }

        public async Task<bool> RemoverPerguntaResposta(int id)
        {
            return await this.service.RemoverPerguntaResposta(id);
        }

        public async Task<ICollection<PerguntaResposta>> RetornarPerguntaRespostaPorPergunta(int perguntaId)
        {
            return await this.service.RetornarPerguntaRespostaPorPergunta(perguntaId);
        }

        public async Task<ICollection<PerguntaResposta>> RetornarPerguntaRespostaPorResposta(int respostaId)
        {
            return await this.service.RetornarPerguntaRespostaPorResposta(respostaId);
        }

        public async Task<ICollection<PerguntaResposta>> RetornarPerguntaRespostaTodos()
        {
            return await this.service.RetornarPerguntaRespostaTodos();
        }
    }
}
