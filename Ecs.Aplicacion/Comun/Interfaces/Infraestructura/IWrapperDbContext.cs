using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Aplicacion.Comun.Interfaces.Infraestructura
{
    public interface IWrapperDbContext
    {
        IAppDbContext Context();
    }
}
