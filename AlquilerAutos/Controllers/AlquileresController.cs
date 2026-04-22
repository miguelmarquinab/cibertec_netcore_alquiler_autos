using AlquilerAutos.Models;
using AlquilerAutos.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlquilerAutos.Controllers
{
    public class AlquileresController : BaseController
    {
        private readonly AlquilerRepository _alquilerRepository;
        private readonly ClienteRepository _clienteRepository;
        private readonly AutoRepository _autoRepository;

        public AlquileresController(
            AlquilerRepository alquilerRepository,
            ClienteRepository clienteRepository,
            AutoRepository autoRepository)
        {
            _alquilerRepository = alquilerRepository;
            _clienteRepository = clienteRepository;
            _autoRepository = autoRepository;
        }

        public IActionResult Index(DateTime? fechaInicio, DateTime? fechaFin, string texto = "")
        {
            var lista = _alquilerRepository.Reporte(fechaInicio, fechaFin, texto);
            ViewBag.FechaInicio = fechaInicio?.ToString("yyyy-MM-dd");
            ViewBag.FechaFin = fechaFin?.ToString("yyyy-MM-dd");
            ViewBag.Texto = texto;
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CargarCombos();
            return View(new AlquilerViewModel
            {
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today.AddDays(1),
                Garantia = 200
            });
        }

        [HttpPost]
        public IActionResult Create(AlquilerViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    CargarCombos();
                    return View(model);
                }

                int idUsuario = HttpContext.Session.GetInt32("idUsuario") ?? 0;
                _alquilerRepository.Registrar(model, idUsuario);

                TempData["ok"] = "Alquiler registrado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                CargarCombos();
                ViewBag.Error = ex.Message;
                return View(model);
            }
        }

        [HttpGet]
        public JsonResult PrecioAuto(int idAuto)
        {
            var auto = _autoRepository.AutosDisponibles().FirstOrDefault(x => x.Id == idAuto);
            if (auto == null) return Json(new { ok = false });

            return Json(new { ok = true, precio = auto.Precio });
        }

        private void CargarCombos()
        {
            ViewBag.Clientes = new SelectList(_clienteRepository.Combo(), "Id", "Texto");
            ViewBag.Autos = new SelectList(_autoRepository.AutosDisponibles(), "Id", "Texto");
        }
    }
}