using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs.Modelo;

namespace Ecs.AltPersistencia.Configuraciones
{
    public class EncuestaConfiguration : EntityTypeConfiguration<Encuesta>
    {
        public EncuestaConfiguration()
        {
            ToTable("Encuestas");
        }
    }
}
