using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlquilerAutos.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var usuario = context.HttpContext.Session.GetString("usuario");
            if (string.IsNullOrEmpty(usuario))
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            ViewBag.Usuario = context.HttpContext.Session.GetString("nombre");
            ViewBag.Rol = context.HttpContext.Session.GetString("rol");

            base.OnActionExecuting(context);
        }

        protected bool EsAdmin()
        {
            return HttpContext.Session.GetString("rol") == "ADMINISTRADOR";
        }
    }
}