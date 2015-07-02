using log4net;
using PollPlus.Web.Mappers;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PollPlus
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();

            var log4NetPath = Server.MapPath("~/Log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(log4NetPath));
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //ILog _log4net = LogManager.GetLogger(typeof(MvcApplication));
            //_log4net.Error(Server.GetLastError());

            //// Clear error from response stream
            //Response.Clear();
            //Server.ClearError();

            //// Redirect user
            //Context.Server.TransferRequest("~/Erro/Index");
        }
    }
}
