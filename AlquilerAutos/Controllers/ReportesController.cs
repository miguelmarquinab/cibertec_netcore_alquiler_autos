using AlquilerAutos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AlquilerAutos.Controllers
{
    public class ReportesController : BaseController
    {
        private readonly AlquilerRepository _alquilerRepository;

        public ReportesController(AlquilerRepository alquilerRepository)
        {
            _alquilerRepository = alquilerRepository;
        }

        public IActionResult Index(DateTime? fechaInicio, DateTime? fechaFin, string texto = "")
        {
            var lista = _alquilerRepository.Reporte(fechaInicio, fechaFin, texto);
            ViewBag.FechaInicio = fechaInicio?.ToString("yyyy-MM-dd");
            ViewBag.FechaFin = fechaFin?.ToString("yyyy-MM-dd");
            ViewBag.Texto = texto;
            return View(lista);
        }
    }
}