using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(PollPlus.Startup))]
namespace PollPlus
{
    public partial class Startup
    {
        //public void Configuration(IAppBuilder app)
        //{
        //    var config = new HttpConfiguration();
        //    WebApiConfig.Register(config);

        //    app.UseNinjectMiddleware(() => NinjectConfig.CreateKernel.Value);
        //    app.UseNinjectWebApi(config);
        //}
    }
}
