using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Modelo
{
    public class Encuesta
    {
        public int Id { get; set; }
        public DateTime Creado { get; set; }
        public string Nombre { get; set; }
        public bool Deshabilitado { get; set; }
    }
}
