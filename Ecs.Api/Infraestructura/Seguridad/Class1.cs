using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Ecs.Aplicacion.Comun.Seguridad;
using Ecs.Modelo;
using Microsoft.Owin.Security.OAuth;

namespace Ecs.Api.Infraestructura.Seguridad
{
    public class Class1
    {
    }

    public class AplicacionAuthServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            using (var db = new AltPersistencia.AppDbContext())
            {
                var rutLimpio = "";

                var usuario = new Usuario() { Id = 1, NombreIngreso = "test", Nombres = "jose", Rol = "admin"};
                var apiControlAcceso = new ApiControlAccesoMock(usuario);

                var resultLoginControlAcceso = await apiControlAcceso.Autenticar(context.UserName, context.Password);
                if (resultLoginControlAcceso.ContrasenaCorrecta)
                {

                    var user = usuario;
                    if (user != null)
                    {
                        AgregarClaims(identity, user);
                        await Task.Run(() => context.Validated(identity));
                    }
                }
                else
                    context.SetError("Credenciales no válidas", "Las credenciales ingresadas no son validas");

                return;
            }
        }

     

        private static void AgregarClaims(ClaimsIdentity identity, Usuario user)
        {
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Rol));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Nombres));
            identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString("dd-MM-yyyy")));
        }

    

        private static bool ApiControlAccesoDeshabilitado()
        {
            return true;
        }

        private bool EsSqlServer()
        {
            return true;
        }
    }

    public class ApiControlAccesoMock : IControlAcceso
    {

        private readonly Usuario _usuario;
        public ApiControlAccesoMock(Usuario usuario)
        {
            _usuario = usuario;
        }

        public Task<LoginResponse> Autenticar(string rut, string contrasena)
        {
            return Task.FromResult<LoginResponse>(new LoginResponse
            {
                ContrasenaCorrecta = _usuario != null,
                RolesUsuario = new ItemRol[] { new ItemRol
                {
                    Descripcion = _usuario?.Rol
                }}
            });
        }

        public Task<UsuarioResponse> ObtenerUsuario(int id, string token)
        {
            return Task.FromResult(new UsuarioResponse());
        }
    }
}