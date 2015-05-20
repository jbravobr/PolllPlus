using Ninject.Modules;
using PollPlus.IRepositorio;
using PollPlus.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.DependecyResolver
{
    public class ModuloRepositorio : NinjectModule
    {
        public override void Load()
        {
            Bind<IEnqueteRepositorio>().To<EnqueteRepositorio>();
        }
    }
}
