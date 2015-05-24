using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
namespace PollPlus.IService
{
    public interface IOpcaoRespostaService
    {
        Task<bool> InserirOpcaoResposta(OpcaoResposta e);
        Task<bool> AtualizarOpcaoResposta(OpcaoResposta e);
        Task<bool> DeletarOpcaoResposta(OpcaoResposta e);
        Task<OpcaoResposta> RetornarOpcaoRespostaPorId(int id);
        Task<ICollection<OpcaoResposta>> RetornarTodasOpcoesRespostas();
    }
}
