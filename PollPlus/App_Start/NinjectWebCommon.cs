[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PollPlus.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(PollPlus.App_Start.NinjectWebCommon), "Stop")]

namespace PollPlus.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Modules;
    using PollPlus.DependecyResolver;
    using Aldeia.Tamis.DependecyResolver;
    using System.Collections.Generic;
    using PollPlus.Service.Interfaces;
    using PollPlus.Service;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var modules = new List<INinjectModule>
            {
                new ModuloRepositorio(),
                new ModuloService()
            };
            kernel.Load(modules);

            kernel.Bind<IUsuarioServiceWEB>().To<UsuarioServiceWEB>().Named("IUsuarioServiceWEB");
            kernel.Bind<IEmpresaServiceWEB>().To<EmpresaServiceWEB>().Named("IEmpresaServiceWEB");
            kernel.Bind<IEnqueteServiceWEB>().To<EnqueteServiceWEB>().Named("IEnqueteServiceWEB");
            kernel.Bind<IPerguntaRespostaServiceWEB>().To<PerguntaRespostaServiceWEB>().Named("IPerguntaRespostaServiceWEB");
            kernel.Bind<IRespostaServiceWEB>().To<RespostaServiceWEB>().Named("IRespostaServiceWEB");
            kernel.Bind<IPerguntaServiceWEB>().To<PerguntaServiceWEB>().Named("PerguntaServiceWEB");
            kernel.Bind<IVoucherServiceWEB>().To<VoucherServiceWEB>().Named("VoucherServiceWEB");
            kernel.Bind<IBannerServiceWEB>().To<BannerServiceWEB>().Named("BannerServiceWEB");
            kernel.Bind<IBlackListServiceWEB>().To<BlackListServiceWEB>().Named("BlackListServiceWEB");
        }
    }
}
