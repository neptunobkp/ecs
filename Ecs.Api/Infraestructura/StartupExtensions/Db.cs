
using SimpleInjector;

namespace Ecs.Api.Infraestructura.StartupExtensions
{
    public static class Db
    {
        public static Container AddDb(this Container container)
        {
            return container;
        }
    }
}