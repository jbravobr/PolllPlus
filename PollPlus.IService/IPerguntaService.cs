using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IService
{
    public interface IPerguntaService
    {
        Task<bool> InserirPergunta(Pergunta e);
        Task<bool> AtualizarPergunta(Pergunta e);
        Task<bool> DeletarPergunta(Pergunta e);
        Task<Pergunta> RetornarPerguntaPorId(int id);
        Task<ICollection<Pergunta>> RetornarTodosPerguntas();

        Task<Pergunta> InserirRetornarPergunta(Pergunta e);
    }
}

