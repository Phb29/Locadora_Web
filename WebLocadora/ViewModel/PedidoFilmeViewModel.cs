using WebLocadora.Models;

namespace WebLocadora.ViewModel
{
    public class PedidoFilmeViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
}
}
