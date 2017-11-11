using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Serilog;
using Serilog.Core;

namespace WebApi.Framework
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var config = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();

            builder.RegisterType<Logger>().As<ILogger>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
