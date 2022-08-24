using Microsoft.AspNetCore.Mvc;

using WebLocadora.Models;
using WebLocadora.Repository.Interface;

namespace WebLocadora.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedido _ipedido;
        private readonly AlugarFilme _alugarfilme;

        public PedidoController(IPedido ipedido, AlugarFilme alugarfilme)
        {
            _ipedido = ipedido;
            _alugarfilme = alugarfilme;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            int totalItensPedido = 0;
            decimal precoTotalPedido = 0.0m;

            //obtem os itens do carrinho de compra do cliente
            List<AlugarFilmeItem> items = _alugarfilme.GetAlugarFilmeItems();
            _alugarfilme.AlugarFilmeItems= items;

            //verifica se existem itens de pedido
            if (_alugarfilme.AlugarFilmeItems.Count == 0)
            {
                ModelState.AddModelError("ErroCarrinhoVazio", "Seu carrinho esta vazio, que tal incluir um Filme...");
                return View();
            }

            //calcula o total d'e itens e o total do pedido
            foreach (var item in items)
            {
                totalItensPedido += item.Quantidade;
                precoTotalPedido += (item.Filme.Preco * item.Quantidade);
            }

            //atribui os valores obtidos ao pedido
            pedido.TotalItensPedido = totalItensPedido;
            pedido.PedidoTotal = precoTotalPedido;

            //valida os dados do pedido
            if (ModelState.IsValid)
            {
                //cria o pedido e os detalhes
                _ipedido.CriarPedido(pedido);

                //define mensagens ao cliente
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido :)";
                ViewBag.TotalPedido = _alugarfilme.CompraTotal();

                //limpa o carrinho do cliente
                _alugarfilme.LimparFilme();

                //exibe a view com dados do cliente e do pedido
                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }
            return View(pedido);
        }
    }
}
