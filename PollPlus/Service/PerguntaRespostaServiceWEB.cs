using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IService;
using PollPlus.Models;
using PollPlus.Domain.Enumeradores;
using PollPlus.Helpers;

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
            var _resposta = new List<PerguntaResposta>();
            if (UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorEmpresa)
                _resposta = (await this.service.RetornarPerguntaRespostaPorPergunta(perguntaId)).Where(u => u.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId).ToList();
            else
                _resposta = (await this.service.RetornarPerguntaRespostaPorPergunta(perguntaId)).ToList();
            return _resposta; 
        }

        public async Task<ICollection<PerguntaResposta>> RetornarPerguntaRespostaPorResposta(int respostaId)
        {
            var _resposta = new List<PerguntaResposta>();
            if (UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorEmpresa)
                _resposta = (await this.service.RetornarPerguntaRespostaPorResposta(respostaId)).Where(u => u.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId).ToList();
            else
                _resposta = (await this.service.RetornarPerguntaRespostaPorResposta(respostaId)).ToList();
            return _resposta;
             
        }

        public async Task<ICollection<PerguntaResposta>> RetornarPerguntaRespostaTodos()
        {
            var _pr = new List<PerguntaResposta>();
            if (UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorEmpresa)
                _pr = (await this.service.RetornarPerguntaRespostaTodos()).Where(u => u.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId).ToList();
            else
                _pr = (await this.service.RetornarPerguntaRespostaTodos()).ToList();
            return _pr; 
        }
    }
}
