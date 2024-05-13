using GestLab.Data;
using GestLab.Models;
using GestLab.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace GestLab.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly ILogger<EstoqueController> _logger;
        private readonly GestLabContext _context;

        public EstoqueController(ILogger<EstoqueController> logger, GestLabContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var produtos = _context.Produto
                .GroupBy(c => new { Tipo = c.Tipo, Cor = c.Cor })
                .Select(g => new EstoqueViewModel()
                {
                    Tipo = g.Key.Tipo,
                    Cor = g.Key.Cor,
                    QuantidadeTotal = g.Count(),
                    QuantidadeDisponivel = g.Count(x => !x.Utilizado),
                    QuantidadeUtilizada = g.Count(x => x.Utilizado)
                }
            );

            return View("Index", produtos);
        }

        public ActionResult Detail()
        {
            var prod = new ProdutoViewModel();
            prod.Cores = StaticLists.ObterCores().Select(x => new SelectListItem() { Text = x, Value = x });
            prod.Tipos = StaticLists.ObterTiposProduto().Select(x => new SelectListItem() { Text = x, Value = x });

            return View("Detail", prod);
        }

        [HttpPost]
        public IActionResult Detail(ProdutoViewModel produtoView)
        {
            for (int i = 0; i < produtoView.Quantidade; i++)
            {
                _context.Produto.Add(new ProdutoModel()
                {
                    Cor = produtoView.Cor,
                    Descricao = produtoView.Descricao,
                    Tipo = produtoView.Tipo,
                    DataEntrada = DateTime.Now
                });
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
