using Microsoft.AspNetCore.Mvc;
using ProyectoFDI.v1.Extension;
using ProyectoFDI.v1.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace ProyectoFDI.v1.Controllers
{
    //[Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Administrador,Deportista,Juez,Entrenador")]
        public IActionResult ListadoDeportistas()
        {
            return View();
        }

        [Authorize(Roles = "Administrador,Entrenador")]
        public IActionResult AdministrarDeportistas()
        {
            return View();
        }

        [Authorize(Roles = "Administrador,Juez,Entrenador")]
        public IActionResult Resultados()
        {
            BasicNotification("Trabajando en ello", NotificationType.Info, "NO DISPONIBLE");
            return View();
        }

        [Authorize(Roles = "Administrador,Juez")]
        public IActionResult Competencias()
        {
            BasicNotification("Trabajando en ello", NotificationType.Info, "NO DISPONIBLE");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}