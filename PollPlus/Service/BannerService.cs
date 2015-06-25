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
            //IEnumerable _empresa = new List<Empresa>();

            //if (UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorEmpresa)
            //    _empresa = (await this.service.RetornarTodosBanners()).Where(u => u.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId);
            //else
            //    _empresa = (await this.service.RetornarTodosBanners());

            return await this.service.RetornarTodosBanners();
        }
    }
}
