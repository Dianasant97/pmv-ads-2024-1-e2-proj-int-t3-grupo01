using GestLab.Data;
using GestLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;

namespace GestLab.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly GestLabContext _context;

        public LoginController(ILogger<LoginController> logger, GestLabContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return PartialView(new LoginModel());
        }

        [HttpPost]
        public IActionResult Index(LoginModel login)
        {
            if (login.Email == "admin@admin.com" && login.Senha == "123!@#")
            {
                HttpContext.Session.SetInt32(SessionKeyID, 0);
                HttpContext.Session.SetString(SessionKeyNome, "Administrador");
                HttpContext.Session.SetString(SessionKeyEmail, login.Email);
                HttpContext.Session.SetString(SessionKeyTipo, "ADM");

                return RedirectToAction("Index", "Home");
            }
            else if (_context.Usuarios.Any(x => x.Email == login.Email && x.Senha == login.Senha))
            {
                UsuarioModel usuario = _context.Usuarios.Where(x => x.Email == login.Email && x.Senha == login.Senha).FirstOrDefault();
                HttpContext.Session.SetInt32(SessionKeyID, usuario.Id);
                HttpContext.Session.SetString(SessionKeyNome, usuario.Nome);
                HttpContext.Session.SetString(SessionKeyEmail, usuario.Email);
                HttpContext.Session.SetString(SessionKeyTipo, usuario.Tipo);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Tipo"] = "Erro";
                TempData["Mensagem"] = "E-mail ou senha inválidos.";

                return PartialView(login);
            }
        }
    }
}
