using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFDI.v1.Code;

namespace ProyectoFDI.v1.Controllers
{
    public class DeportistaController : Controller
    {
        string apiUrl = "https://localhost:7078/api/Deportistums";
        // GET: DeportistaController
        public ActionResult Index()
        {
            var data = APIConsumer.Deportistas(apiUrl);
            return View(data);
        }

        // GET: DeportistaController/Details/5
        public ActionResult Details(int id)
        {
            var data = APIConsumer.Deportista(apiUrl, id);
            return View(data);
        }

        // GET: DeportistaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeportistaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Deportistum deportista)
        {
            try
            {
                var newdata = APIConsumer.CrearDeportista(apiUrl,deportista);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(deportista);
            }
        }

        // GET: DeportistaController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = APIConsumer.Deportista(apiUrl, id);
            return View(data);
        }

        // POST: DeportistaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.Deportistum deportista)
        {
            try
            {
                APIConsumer.GuardarDeportista(apiUrl, id, deportista);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(deportista);
            }
        }

        // GET: DeportistaController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = APIConsumer.Deportista(apiUrl, id);
            return View(data);
        }

        // POST: DeportistaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                APIConsumer.BorrarDeportista(apiUrl, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
