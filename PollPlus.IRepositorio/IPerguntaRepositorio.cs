using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IPerguntaRepositorio
    {
        Task<bool> InserirPergunta(Pergunta r);
        Task<bool> AtualizarPergunta(Pergunta r);
        Task<bool> DeletarPergunta(Pergunta r);
        Task<Pergunta> RetornarPerguntaPorId(int id);
        Task<ICollection<Pergunta>> RetornarTodasPerguntas();

        Task<Pergunta> InserirRetornarPergunta(Pergunta e);
    }
}

