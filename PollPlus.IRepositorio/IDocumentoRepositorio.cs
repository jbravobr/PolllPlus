using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IDocumentoRepositorio
    {
        Task<bool> InserirDocumento(Documento e);
        Task<bool> AtualizarDocumento(Documento e);
        Task<bool> DeletarDocumento(Documento e);
        Task<Documento> RetornarDocumentoPorId(int id);
        Task<ICollection<Documento>> RetornarTodosDocumentos();
    }
}

