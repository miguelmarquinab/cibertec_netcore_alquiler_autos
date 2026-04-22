using AlquilerAutos.Helpers;
using AlquilerAutos.Models;
using AlquilerAutos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AlquilerAutos.Controllers
{
    public class AccountController : Controller
    {
        private readonly UsuarioRepository _usuarioRepository;

        public AccountController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("usuario") != null)
                return RedirectToAction("Index", "Dashboard");

            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuario = _usuarioRepository.Login(model.Usuario, model.Clave);
            if (usuario == null)
            {
                ViewBag.Error = "Usuario o clave incorrectos";
                return View(model);
            }

            HttpContext.Session.SetString("usuario", usuario.Usuario);
            HttpContext.Session.SetString("nombre", usuario.NombreCompleto);
            HttpContext.Session.SetString("rol", usuario.NombreRol);
            HttpContext.Session.SetInt32("idUsuario", usuario.IdUsuario);
            HttpContext.Session.SetObject("sesion", usuario);

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}