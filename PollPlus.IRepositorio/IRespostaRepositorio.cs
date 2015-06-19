using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IRespostaRepositorio
    {
        Task<bool> InserirResposta(Resposta r);
        Task<bool> AtualizarResposta(Resposta r);
        Task<bool> DeletarResposta(Resposta r);
        Task<Resposta> RetornarRespostaPorId(int id);
        Task<ICollection<Resposta>> RetornarTodasRespostas();
    }
}

