using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using Ecs.Api.Infraestructura.Handlers;
using Ecs.Api.Infraestructura.StartupExtensions;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

[assembly: OwinStartup(typeof(Ecs.Api.Startup))]

namespace Ecs.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigurarDependencias(app);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }

        public void ConfigurarDependencias(IAppBuilder app)
        {
            var container = new Container();
            container.AddInjectorOpt(app)
                .AddDb()
                .AddWebApi(GlobalConfiguration.Configuration)
                .Verify();

            app.UseOwinExceptionHandler();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            ConfiguradorWebApi.ConfigurarAuth(app);
        }
    }
}
