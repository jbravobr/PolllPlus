using PollPlus.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.Repositorio.EFContext;
using System.Linq.Expressions;

namespace PollPlus.Repositorio
{
    public class PerguntaRespostaRepositorio : BaseRepositorio<PerguntaResposta, PollPlusContext<PerguntaResposta>>, IPerguntaRespostaRepositorio
    {
        public async Task<bool> AtualizarPerguntaResposta(PerguntaResposta pr)
        {
            base.Atualizar(pr);
            return await base.Salvar();
        }

        public async Task<bool> InserirPerguntaResposta(PerguntaResposta ec)
        {
            base.Inserir(ec);
            return await base.Salvar();
        }

        public async Task<bool> RemoverPerguntaResposta(int id)
        {
            Expression<Func<PerguntaResposta, bool>> porId = (x) => x.Id == id;
            var entity = await base.RetornarPorId(porId);

            base.Deletar(entity);

            return await Task.FromResult<bool>(true);
        }

        public async Task<ICollection<PerguntaResposta>> RetornarPerguntaRespostaPorPergunta(int perguntaId)
        {
            Expression<Func<PerguntaResposta, bool>> porPergunta = (x) => x.PerguntaId == perguntaId;
            return await base.ProcurarPorColecao(porPergunta);
        }

        public async Task<ICollection<PerguntaResposta>> RetornarPerguntaRespostaPorResposta(int respostaId)
        {
            Expression<Func<PerguntaResposta, bool>> porResposta = (x) => x.RespostaId == respostaId;
            return await base.ProcurarPorColecao(porResposta);
        }

        public async Task<ICollection<PerguntaResposta>> RetornarPerguntaRespostaTodos()
        {
            return await base.RetornarTodos();
        }
    }
}
