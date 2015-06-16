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
        }
    }
}
