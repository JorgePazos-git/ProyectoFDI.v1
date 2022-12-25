using Microsoft.AspNetCore.Mvc;
using ProyectoFDI.Models;
using ProyectoFDI.Logica;
using System.Web;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ProyectoFDI.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string nombre_usu, string contraseña_usu)
        {
            Usuarios objeto = new LO_Usuario().EncontrarUsuario(nombre_usu, contraseña_usu);

            if (objeto != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            
        }
    }
}
