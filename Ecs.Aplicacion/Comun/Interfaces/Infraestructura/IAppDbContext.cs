using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ecs.Modelo;

namespace Ecs.Aplicacion.Comun.Interfaces.Infraestructura
{
    public interface IAppDbContext : IDisposable
    {
        DbSet<Encuesta> Encuestas { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
        DbEntityEntry Entry(object entity);
    }
}
