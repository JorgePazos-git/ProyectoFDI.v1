using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFDI.Extensions;
using ProyectoFDI.Models;
using System.Diagnostics;

namespace ProyectoFDI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            BasicNotification("Sistema FDI", NotificationType.Success, "Bienvenido!!");
            return View();
        }

        public IActionResult CerrarSesion()
        {
            return RedirectToAction("Index", "Acceso");
        }

        public IActionResult Login()
        {
           
            return View();
        }
        public IActionResult Privacy()
        {

            return View();
        }

        public IActionResult Create()
        {
            //el metodo de crear retorno true
            if (true)
            {
                
            }
            
            return RedirectToAction(nameof(Privacy));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}