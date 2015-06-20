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
            Bind<ICategoriaRepositorio>().To<CategoriaRepositorio>();
            Bind<IUsuarioRepositorio>().To<UsuarioRepositorio>();
            Bind<IUsuarioCategoriaRepositorio>().To<UsuarioCategoriaRepositorio>();
            Bind<IEmpresaRepositorio>().To<EmpresaRepositorio>();
            Bind<IPerguntaRespostaRepositorio>().To<PerguntaRespostaRepositorio>();
            Bind<IRespostaRepositorio>().To<RespostaRepositorio>();
            Bind<IPerguntaRepositorio>().To<PerguntaRepositorio>();
            Bind<IVoucherRepositorio>().To<VoucherRepositorio>();
        }
    }
}
