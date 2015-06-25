using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IService;
using PollPlus.Helpers;
using PollPlus.Domain.Enumeradores;

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
            var _pergunta = new List<Pergunta>();
            if (UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorEmpresa)
                _pergunta = (await this._service.RetornarTodosPerguntas()).Where(u => u.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId).ToList();
            else
                _pergunta = (await this._service.RetornarTodosPerguntas()).ToList();
            return _pergunta;
        }
    }
}
