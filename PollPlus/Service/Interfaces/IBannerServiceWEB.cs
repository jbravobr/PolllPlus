﻿using PollPlus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Service.Interfaces
{
    public interface IBannerServiceWEB
    {
        Task<bool> InserirBanner(Banner r);
        Task<bool> DeletarBanner(Banner r);
        Task<Banner> RetornarBannerPorId(int id);
        Task<ICollection<Banner>> RetornarBannerPorEmpresaId(int empresaId);
        Task<ICollection<Banner>> RetornarTodosBanners();
    }
}
