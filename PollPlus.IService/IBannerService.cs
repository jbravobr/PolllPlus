using PollPlus.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;

namespace PollPlus.IService
{
    public interface IBannerService
    {
        Task<bool> InserirBanner(Banner r);
        Task<bool> DeletarBanner(Banner r);
        Task<Banner> RetornarBannerPorId(int id);
        Task<Banner> InserirRetornarBanner(Banner r);
        Task<ICollection<Banner>> RetornarBannerPorEmpresaId(int empresaId);
        Task<ICollection<Banner>> RetornarTodosBanners();
    }
}
