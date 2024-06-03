using GestLab.Data;
using GestLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestLab.Controllers
{
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly GestLabContext _context;

        public ClientesController(ILogger<ClientesController> logger, GestLabContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var usuario = _context.Usuarios.ToList();
            return View("Index",usuario);
        }

        [HttpPost]
        public IActionResult Detail(ClienteModel cliente)
        {
            if(cliente.Id ==0)
                _context.Cliente.Add(cliente);
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
