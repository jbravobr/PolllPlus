using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Service.Interfaces
{
    public interface IRespostaServiceWEB
    {
        Task<bool> InserirResposta(Resposta e);
        Task<bool> AtualizarResposta(Resposta e);
        Task<bool> DeletarResposta(Resposta e);
        Task<Resposta> RetornarRespostaPorId(int id);
        Task<ICollection<Resposta>> RetornarTodosRespostas();

        Task<Resposta> InserirRetornarResposta(Resposta r);
    }
}
