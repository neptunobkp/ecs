using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Aplicacion.Comun.Seguridad
{
    public interface IControlAcceso
    {
        Task<LoginResponse> Autenticar(string rut, string contrasena);

        Task<UsuarioResponse> ObtenerUsuario(int id, string token);
    }
}
