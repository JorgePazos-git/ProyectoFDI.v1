using Microsoft.AspNetCore.Mvc;

namespace ProyectoFDI.Extensions
{
    public enum NotificationType
    {
        Success,
        Error,
        Info
    }
    public class BaseController : Controller
    {
        public void BasicNotification(string msj, NotificationType type, string title = "")
        {
            TempData["notification"] = $"Swal.fire('{title}','{msj}', '{type.ToString().ToLower()}')";
        }

    }
}
