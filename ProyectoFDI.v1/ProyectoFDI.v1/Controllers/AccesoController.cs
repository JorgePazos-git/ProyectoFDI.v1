using Microsoft.AspNetCore.Mvc;
using ProyectoFDI.v1.Extension;
using ProyectoFDI.v1.Models;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ProyectoFDI.v1.Controllers
{
    public class AccesoController : BaseController
    {
        public ProyectoFdiContext _context;

        public AccesoController(ProyectoFdiContext master)
        {
            this._context = master;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Salir()
        {
            BasicNotification("Sesion Cerrada", NotificationType.Success);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acceso");
        }

        public Usuario ValidarUsuario(string nombre, string clave)
        {
            return _context.Usuarios.Where(s => s.NombreUsuario == nombre && s.ClaveUsuario == clave).FirstOrDefault();

        }
        [HttpPost]
        public async Task<IActionResult> Index(Usuario user)
        {
            Usuario usuario = ValidarUsuario(user.NombreUsuario, user.ClaveUsuario);

            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario)
                };

                string[]Roles = usuario.RolesUsuario.Split(',');

                foreach(string rol in Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                BasicNotification(usuario.RolesUsuario, NotificationType.Info, "Rol");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                BasicNotification("Ingrese un usuario y contraseña validos", NotificationType.Error, "ERROR");
                return View();
            } 
        }



    }
}
