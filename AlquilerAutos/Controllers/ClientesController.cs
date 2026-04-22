using AlquilerAutos.Models;
using AlquilerAutos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AlquilerAutos.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly ClienteRepository _clienteRepository;

        public ClientesController(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index(string texto = "")
        {
            var lista = _clienteRepository.Listar(texto);
            ViewBag.Texto = texto;
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Form", new ClienteViewModel());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _clienteRepository.Obtener(id);
            if (model == null) return RedirectToAction("Index");
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Save(ClienteViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Form", model);

            _clienteRepository.Guardar(model);
            TempData["ok"] = "Cliente guardado correctamente";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _clienteRepository.Eliminar(id);
            return Json(new { ok = true, mensaje = "Cliente eliminado correctamente" });
        }
    }
}