using WebLocadora.Context;
using WebLocadora.Models;
using WebLocadora.Repository.Interface;

namespace WebLocadora.Repository
{
    public class PedidoRepository : IPedido
    {
        private readonly AppDbContext _context;
        private readonly AlugarFilme _alugarFime;

        public PedidoRepository(AppDbContext context, AlugarFilme alugarFime)
        {
            _context = context;
            _alugarFime = alugarFime;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _context.Add(pedido);
            _context.SaveChanges();

            var alugarfilme = _alugarFime.AlugarFilmeItems;
            foreach(var item in alugarfilme)
            {
                var pedidodetalhe = new PedidoDetalhe
                {
                    Qunatidade = item.Quantidade,
                    FilmeId = item.Filme.FilmeId,
                    PedidoId = pedido.PedidoId,
                    Preco = item.Filme.Preco,
                    

                   
                };
                _context.PedidoDetalhes.Add(pedidodetalhe);
            }
            _context.SaveChanges();
        }
    }
}
