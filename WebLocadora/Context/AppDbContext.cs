using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebLocadora.Models;

namespace WebLocadora.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Filme> Filmes { get; set; }
       
        public DbSet<FilmeCategoria> FilmeCategorias { get; set; }
        public DbSet<AlugarFilmeItem> AlugarFilmeItems { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
        public DbSet<WebLocadora.Models.AlugarFilme> AlugarFilme { get; set; }

    }


}

