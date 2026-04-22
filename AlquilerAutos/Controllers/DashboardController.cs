using AlquilerAutos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AlquilerAutos.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly DashboardRepository _dashboardRepository;

        public DashboardController(DashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public IActionResult Index()
        {
            var model = _dashboardRepository.Obtener();
            return View(model);
        }
    }
}