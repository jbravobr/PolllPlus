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
    public class RespostaServiceWEB : IRespostaServiceWEB
    {
        readonly IRespostaService _service;

        public RespostaServiceWEB(IRespostaService service)
        {
            this._service = service;
        }

        public async Task<Resposta> InserirRetornarResposta(Resposta r)
        {
            return await this._service.InserirRetornarResposta(r);
        }

        public async Task<bool> AtualizarResposta(Resposta e)
        {
            return await this._service.AtualizarResposta(e);
        }

        public async Task<bool> DeletarResposta(Resposta e)
        {
            return await this._service.DeletarResposta(e);
        }

        public async Task<bool> InserirResposta(Resposta e)
        {
            return await this._service.InserirResposta(e);
        }

        public async Task<Resposta> RetornarRespostaPorId(int id)
        {
            return await this._service.RetornarRespostaPorId(id);
        }

        public async Task<ICollection<Resposta>> RetornarTodosRespostas()
        {
            return await this._service.RetornarTodosRespostas();
        }
    }
}
