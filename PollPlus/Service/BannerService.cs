using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPlus.Domain;
using PollPlus.IService;
using PollPlus.Models;
using PollPlus.Domain.Enumeradores;
using PollPlus.Helpers;

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

        public async Task<Banner> InserirRetornarBanner(Banner e)
        {
            return await this.service.InserirRetornarBanner(e);
        }

        public async Task<bool> InserirBanner(Banner e)
        {
            return await this.service.InserirBanner(e);
        }

        public async Task<ICollection<Banner>> RetornarBannerPorEmpresaId(int empresaId)
        {
            var _banner = new List<Banner>();

            if (UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorEmpresa)
                _banner = (await this.service.RetornarBannerPorEmpresaId(empresaId)).Where(u => u.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId).ToList();
            else
                _banner = (await this.service.RetornarBannerPorEmpresaId(empresaId)).ToList();

            return _banner;
        }

        public async Task<Banner> RetornarBannerPorId(int id)
        {
            return await this.service.RetornarBannerPorId(id);
        }

        public async Task<ICollection<Banner>> RetornarTodosBanners()
        {
            var _banner = new List<Banner>();

            if (UsuarioLogado.UsuarioAutenticado().Perfil == EnumPerfil.AdministradorEmpresa)
                _banner = (await this.service.RetornarTodosBanners()).Where(u => u.Id == UsuarioLogado.UsuarioAutenticado().EmpresaId).ToList();
            else
                _banner = (await this.service.RetornarTodosBanners()).ToList();

            return _banner;
        }
    }
}
