using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IService;

namespace PollPlus.Service
{
    public class BannerServiceWEB : IBannerServiceWEB
    {
        readonly IBannerService service;

        public BannerServiceWEB(IBannerService _service)
        {
            this.service = _service;
        }

        public async Task<bool> DeletarBanner(Banner e)
        {
            return await this.service.DeletarBanner(e);
        }

        public async Task<bool> InserirBanner(Banner e)
        {
            return await this.service.InserirBanner(e);
        }

        public async Task<ICollection<Banner>> RetornarBannerPorEmpresaId(int empresaId)
        {
            return await this.service.RetornarBannerPorEmpresaId(empresaId);
        }

        public async Task<Banner> RetornarBannerPorId(int id)
        {
            return await this.service.RetornarBannerPorId(id);
        }

        public async Task<ICollection<Banner>> RetornarTodosBanners()
        {
            return await this.service.RetornarTodosBanners();
        }
    }
}
