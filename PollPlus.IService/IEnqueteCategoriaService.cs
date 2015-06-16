using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IEnqueteCategoriaService
    {
        Task<bool> InserirEnqueteCategoria(EnqueteCategoria ec);
        Task<bool> RemoverEnqueteCategoria(int id);
        Task<ICollection<EnqueteCategoria>> RetornarEnqueteCategoriaEnquete(int enqueteId);
        Task<ICollection<EnqueteCategoria>> RetornarEnqueteCategoriaCategoria(int categoriaId);
        Task<ICollection<EnqueteCategoria>> RetornarEnqueteCategoriaTodos();
    }
}
