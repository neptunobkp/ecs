namespace Ecs.Aplicacion.Comun.Seguridad
{
    public class LoginResponse
    {
        public int IdUsuario { get; set; }
        public bool ContrasenaCorrecta { get; set; }
        public ItemToken[] ListadoTokenes { get; set; }
        public ItemRol[] RolesUsuario { get; set; }
    }
}