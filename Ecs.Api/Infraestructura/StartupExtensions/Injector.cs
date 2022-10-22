using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Ecs.Api.Infraestructura.StartupExtensions
{

    public static class Injector
    {
        public static Container AddInjectorOpt(this Container container, IAppBuilder app)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            app.Use(async (context, next) => { using (AsyncScopedLifestyle.BeginScope(container)) { await next(); } });
            return container;
        }
    }
}