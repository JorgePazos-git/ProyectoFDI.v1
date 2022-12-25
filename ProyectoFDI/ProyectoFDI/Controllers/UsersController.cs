//using Microsoft.AspNetCore.Mvc;
//using ProyectoFDI.Models;

//namespace ProyectoFDI.Controllers
//{
//    public class UsersController : Controller
//    {
//        public ProyectoFdiContext _context;

//        public UsersController(ProyectoFdiContext master)
//        {
//            this._context = master;
//        }

//        [HttpPost]
//        public IActionResult GetUsers (string user, string pass)
//        {
//            var usuario = _context.Users.Where(s => s.NameUsers == user && s.PasswordUsers == pass);

//            if (usuario.Any())
//            {
//                if (usuario.Where(s => s.NameUsers == user && s.PasswordUsers == pass).Any())
//                {
//                    return Json(new { status = true, message = "Bienvenido" });
//                }
//                else
//                {
//                    return Json(new { status = false, message = "Clave Incorrecta" });
//                }
//            }
//            else
//            {
//                return Json(new { status = false, message = "Usuario Incorrecto" });
//            }
//        }
//    }
//}
