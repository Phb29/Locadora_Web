using Microsoft.EntityFrameworkCore;
using WebLocadora.Context;

namespace WebLocadora.Models
{
    public class AlugarFilme
    {
        private readonly AppDbContext _context;

        public AlugarFilme(AppDbContext context)
        {
            _context = context;
        }
        public string AlugarFilmeId { get; set; }
        public List<AlugarFilmeItem> AlugarFilmeItems { get; set; } 

        public static AlugarFilme GetFilme(IServiceProvider services)
        {
            //Define Sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo  do nosso contexto
            var context = services.GetService<AppDbContext>();

            //Obtem ou gera Id do Alugarfilme
            string filmeId = session.GetString("FilmeId") ?? Guid.NewGuid().ToString();

            //atribui o id ao carrinho na Sessao
            session.SetString("FilmeId", filmeId);

            return new AlugarFilme(context)
            {
                AlugarFilmeId = filmeId
                
            };
            
        }
        public void AdicionarFilme(Filme filme)
        {
            var aluguefilmeitem = _context.AlugarFilmeItems.FirstOrDefault(f => f.Filme
            .FilmeId == filme.FilmeId && f.AlugarFilmeId==AlugarFilmeId );

            if(aluguefilmeitem == null)
            {
                aluguefilmeitem = new AlugarFilmeItem
                {
                    AlugarFilmeId = AlugarFilmeId,
                    Filme = filme,
                    Quantidade = 1
                };
                _context.Add(aluguefilmeitem);
            }
            else
            {
                aluguefilmeitem.Quantidade++;
            }
           
            _context.SaveChanges();

        }
        // pode usar int se quiser
        public void RemoverFilme(Filme filme)
        {
            var aluguefilmeitem = _context.AlugarFilmeItems.FirstOrDefault(f=>f.
            Filme.FilmeId==filme.FilmeId && f.AlugarFilmeId==AlugarFilmeId);
            // var quantidadeLocal = 0;
            if (aluguefilmeitem != null)
            {
                if(aluguefilmeitem.Quantidade > 1)
                {
                    aluguefilmeitem.Quantidade--;
                    // quantidadeLocal= aluguefilmeitem.Quantidade;
                }
                else

                {
                    _context.AlugarFilmeItems.Remove(aluguefilmeitem);
                }                
            }
            _context.SaveChanges();
            // return quantidadeLocal;
        }
        public List<AlugarFilmeItem> GetAlugarFilmeItems()
        {
            return AlugarFilmeItems ?? (AlugarFilmeItems =
                      _context.AlugarFilmeItems.Where(c => c.AlugarFilmeId == AlugarFilmeId)
                          .Include(s => s.Filme)
                          .ToList());
        }
        public void LimparFilme()
        {
            var alugarfilmeitem = _context.AlugarFilmeItems.Where(f => f.AlugarFilmeId == AlugarFilmeId);
            _context.AlugarFilmeItems.RemoveRange(alugarfilmeitem);
            _context.SaveChanges();
        }   
        public decimal CompraTotal()
        {
            var total = _context.AlugarFilmeItems.Where(f => f.AlugarFilmeId == AlugarFilmeId)
                .Select(c => c.Filme.Preco * c.Quantidade).Sum();
            
            return total;
        }

    }
}
