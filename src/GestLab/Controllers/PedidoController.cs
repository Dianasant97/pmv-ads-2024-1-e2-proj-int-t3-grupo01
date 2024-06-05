using GestLab.Data;
using GestLab.Models;
using GestLab.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestLab.Controllers
{
    public class PedidoController : ControllerBase
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly GestLabContext _context;

        public PedidoController(ILogger<PedidoController> logger, GestLabContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var usuarioLogado = base.GetDadosUsuario();
            var pedido = _context.Pedido.Include(x => x.Cliente).AsQueryable();

            switch (usuarioLogado.Tipo)
            {
                case "Cliente":
                    pedido = pedido.Where(l => l.Cliente.IdUsuario == usuarioLogado.Id);
                    break;
                case "Montador":
                    pedido = pedido.Where(l => l.MontadorResponsavel.Id == usuarioLogado.Id);
                    break;
                case "Assistente":
                    //pedido = pedido.Where(l => l.i .Id == usuarioLogado.Id);
                    break;
                default:
                    //administrador
                    break;
            }

            pedido.ToList();
            return View("Index", pedido);
        }

        [HttpPost]
        public IActionResult Detail(PedidoViewModel pedidoView)
        {
            var pedido = RecuperaPedido(pedidoView.Pedido.Id);
            pedido.Aplicar(pedidoView.Pedido);

            //gambi provisoria para cliente, campo deve virar um combo com os clientes disponiveis
            var cliente = _context.Cliente.FirstOrDefault(x => x.Id == pedido.Cliente.Id);
            if (cliente == null)
            {
                var cli = _context.Cliente.Add(new ClienteModel() { Nome = "Cliente manual" });
                pedido.Cliente = cli.Entity;
            }
            else
                pedido.Cliente = cliente;

            var possuiArmacao = pedido.ArmacaoEntreguePeloCliente;
            if (pedido.ArmacaoEntreguePeloCliente && (pedido.Armacao == null || pedido.Armacao.Id == 0))
            {
                possuiArmacao = true;
                var armacao = new ProdutoModel();
                armacao.DataSaida = armacao.DataEntrada = DateTime.Now;
                armacao.Descricao = pedido.IdentificacaoArmacao;
                armacao.Tipo = "Arma��o";
                armacao.Cor = "-";
                armacao.Utilizado = true;
                pedido.Armacao = armacao;
            }

            if (!pedido.PossuiLentesEmEstoque)
            {
                var lentes = _context.Produto.Where(x => x.Tipo == "Lentes" && !x.Utilizado && x.Cor == pedido.CorLentes)?.Take(2)?.ToList();
                if (lentes?.Count() == 2)
                {
                    pedido.PossuiLentesEmEstoque = true;
                    pedido.LenteEsquerda = lentes.First();
                    pedido.LenteDireita = lentes.Last();
                    pedido.LenteDireita.Utilizado = pedido.LenteEsquerda.Utilizado = true;
                    pedido.LenteDireita.DataSaida = pedido.LenteEsquerda.DataSaida = DateTime.Now;
                }
            }

            if (!possuiArmacao && !pedido.PossuiLentesEmEstoque)
                pedido.Status = "Pendente Lentes e Arma��o";
            else if (!possuiArmacao)
                pedido.Status = "Pendente Arma��o";
            else if (!pedido.PossuiLentesEmEstoque)
                pedido.Status = "Pendente Lentes";
            else
                pedido.Status = "Novo";

            if (pedido.Id == 0)
            {
                pedido.DataPedido = DateTime.Now;
                _context.Pedido.Add(pedido);
            }
            else
                _context.Pedido.Update(pedido);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var pedido = RecuperaPedido(id);

            if (pedido == null)
            {
                return NotFound();
            }

            PedidoViewModel pedidoModel = new(pedido);
            pedidoModel.Cores = StaticLists.ObterCores().Select(x => new SelectListItem() { Text = x, Value = x });

            return View("Detail", pedidoModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private PedidoModel RecuperaPedido(int id)
        {
            PedidoModel pedido = null;

            if (id > 0)
            {
                pedido = _context.Pedido
                    .Where(x => x.Id == id)
                    .Include(x => x.Receita)
                    .Include(x => x.LenteDireita)
                    .Include(x => x.LenteEsquerda)
                    .Include(x => x.Armacao)
                    .FirstOrDefault();
            }

            if (id == 0) pedido = new();

            return pedido;
        }
        public async Task<IActionResult> Relatorio(int? id, int? mes, int? ano)
        {
            if (id == null)
                return NotFound();

            var pedido = await _context.Pedido.FindAsync(id);

            if (pedido == null)
                return NotFound();

            var Pedido = await _context.Pedido
                .Include(x => x.Receita)
                .OrderByDescending(c => c.DataPedido)
                .ToListAsync();


            var mesAno = $"{mes}/{ano}";

            // Passar os dados para a view
            ViewBag.Pedido = pedido;
            ViewBag.MesAno = mesAno;


            return View(pedido);

        }
    }
}
