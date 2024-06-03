using GestLab.Data;
using GestLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestLab.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var usuario = GetDadosUsuario();
            if (string.IsNullOrEmpty(usuario.Nome))
                return RedirectToAction("Index", "Login");

            var d = HttpContext.Session.GetString(SessionKeyNome) ?? "";
            if(d == null || d == "")
            {
                return RedirectToAction("Index", "Login");
            }


            return View(usuario);
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
    }
}
