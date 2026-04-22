using AlquilerAutos.Models;
using AlquilerAutos.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlquilerAutos.Controllers
{
    public class AutosController : BaseController
    {
        private readonly AutoRepository _autoRepository;

        public AutosController(AutoRepository autoRepository)
        {
            _autoRepository = autoRepository;
        }

        public IActionResult Index(string texto = "", string estado = "", int pagina = 1)
        {
            var model = _autoRepository.Listar(texto, estado, pagina, 8);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!EsAdmin()) return RedirectToAction("Index");
            CargarMarcas();
            return View("Form", new AutoViewModel { Estado = "DISPONIBLE", Anio = DateTime.Now.Year });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!EsAdmin()) return RedirectToAction("Index");
            CargarMarcas();
            var model = _autoRepository.Obtener(id);
            if (model == null) return RedirectToAction("Index");
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Save(AutoViewModel model)
        {
            if (!EsAdmin()) return RedirectToAction("Index");

            if (!ModelState.IsValid)
            {
                CargarMarcas();
                return View("Form", model);
            }

            _autoRepository.Guardar(model);
            TempData["ok"] = "Auto guardado correctamente";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (!EsAdmin())
                return Json(new { ok = false, mensaje = "No autorizado" });

            _autoRepository.Eliminar(id);
            return Json(new { ok = true, mensaje = "Auto eliminado correctamente" });
        }

        private void CargarMarcas()
        {
            ViewBag.Marcas = new SelectList(_autoRepository.Marcas(), "IdMarca", "NombreMarca");
        }
    }
}