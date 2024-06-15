using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PR2_WEBCORE.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace PR2_WEBCORE.Controllers
{
    [Authorize(Roles = "Administrador,Asesor")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            string NombreUsuario = "";

            if (claimuser.Identity.IsAuthenticated)
            {
                NombreUsuario = claimuser.Claims
                    .Where(c => c.Type == ClaimTypes.Name)
                    .Select(c => c.Value)
                    .SingleOrDefault();
            }

            ViewData["nombreUsuario"] = NombreUsuario;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("IniciarSesion", "Inicio");
        }
    }
}
