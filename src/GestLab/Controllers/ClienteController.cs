using GestLab.Data;
using GestLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestLab.Controllers
{
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly GestLabContext _context;

        public ClienteController(ILogger<ClienteController> logger, GestLabContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var clientes = _context.Cliente.ToList();
            return View("Index", clientes);
        }

        [HttpPost]
        public IActionResult Detail(ClienteModel cliente)
        {
            if (cliente.Id == 0) 
            {
                var usuario = new UsuarioModel
                {
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Senha = cliente.Cnpj,
                    Tipo = "Cliente",
                    Telefone = cliente.Telefone,
                };

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                cliente.IdUsuario = usuario.Id;
                _context.Cliente.Add(cliente);
            }
            else
                _context.Cliente.Update(cliente);
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int? id)
        {
            if (id == 0)
            {
                return View("Detail", new ClienteModel());
            }

            if (id == null)
            {
                return NotFound();
            }

            var cliente = _context.Cliente.Find(id);

            return View("Detail", cliente);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
