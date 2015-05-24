using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IMensagemRepositorio
    {
        Task<bool> InserirMensagem(Mensagem e);
        Task<bool> AtualizarMensagem(Mensagem e);
        Task<bool> DeletarMensagem(Mensagem e);
        Task<Mensagem> RetornarMensagemPorId(int id);
        Task<ICollection<Mensagem>> RetornarTodasMensagens();
    }
}
