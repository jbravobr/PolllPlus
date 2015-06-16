using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IPerguntaRespostaService
    {
        Task<bool> InserirPerguntaResposta(PerguntaResposta pr);
        Task<bool> RemoverPerguntaResposta(int id);
        Task<bool> AtualizarPerguntaResposta(PerguntaResposta pr);
        Task<ICollection<PerguntaResposta>> RetornarPerguntaRespostaPorPergunta(int perguntaId);
        Task<ICollection<PerguntaResposta>> RetornarPerguntaRespostaPorResposta(int respostaId);
        Task<ICollection<PerguntaResposta>> RetornarPerguntaRespostaTodos();
    }
}
