using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.IRepositorio
{
    public interface IBannerRepositorio
    {
        Task<bool> InserirBanner(Banner r);
        Task<bool> DeletarBanner(Banner r);
        Task<bool> AtualizarBanner(Banner r);
        Task<Banner> RetornarBannerPorId(int id);
        Task<Banner> InserirRetornarBanner(Banner r);
        Task<ICollection<Banner>> RetornarBannerPorEmpresaId(int empresaId);
        Task<ICollection<Banner>> RetornarTodosBanners();
    }
}

