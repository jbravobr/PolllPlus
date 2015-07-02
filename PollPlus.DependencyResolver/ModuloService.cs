using Ninject.Modules;
using PollPlus.IService;
using PollPlus.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aldeia.Tamis.DependecyResolver
{
    public class ModuloService : NinjectModule
    {
        public override void Load()
        {
            Bind<IEnqueteService>().To<EnqueteService>();
            Bind<ICategoriaService>().To<CategoriaService>();
            Bind<IUsuarioService>().To<UsuarioService>();
            Bind<IUsuarioCategoriaService>().To<UsuarioCategoriaService>();
            Bind<IEmpresaService>().To<EmpresaService>();
            Bind<IPerguntaRespostaService>().To<PerguntaRespostaService>();
            Bind<IRespostaService>().To<RespostaService>();
            Bind<IPerguntaService>().To<PerguntaService>();
            Bind<IVoucherService>().To<VoucherService>();
            Bind<IBannerService>().To<BannerService>();
            Bind<IBlackListService>().To<BlackListService>();
            Bind<IEnqueteCategoriaService>().To<EnqueteCategoriaService>();
            Bind<IEnqueteVoucherService>().To<EnqueteVoucherService>();
        }
    }
}
