using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs.AltPersistencia.Configuraciones;
using Ecs.Aplicacion.Comun.Interfaces.Infraestructura;
using Ecs.Modelo;

namespace Ecs.AltPersistencia
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext() : base("SqlDb")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Encuesta> Encuestas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new EncuestaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
