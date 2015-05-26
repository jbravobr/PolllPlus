using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PollPlus.Startup))]
namespace PollPlus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
