using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IMensagemCategoriaRepositorio
    {
        Task<bool> InserirMensagemCategoria(MensagemCategoria mc);
        Task<bool> RemoverMensagemCategoria(int id);
        Task<ICollection<MensagemCategoria>> RetornarMensagemCategoriaPorMensagem(int mensagemId);
        Task<ICollection<MensagemCategoria>> RetornarMensagemCategoriaPorCategoria(int categoriaId);
        Task<ICollection<MensagemCategoria>> RetornarMensagemCategoriaTodos();
    }
}
}
