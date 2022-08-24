using Microsoft.EntityFrameworkCore;
using WebLocadora.Context;
using WebLocadora.Models;

namespace WebLocadora.Areas.Admin.Servicos
{
    public class RelatorioVendasService
    {
        private readonly AppDbContext _context;

        public RelatorioVendasService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.Pedidos select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }

            return await resultado
                         .Include(l => l.PedidoItens)
                         .ThenInclude(l => l.Filme)
                         .OrderByDescending(x => x.PedidoEnviado)
                         .ToListAsync();

        }
    }
}