using Microsoft.EntityFrameworkCore;
using WebLocadora.Context;
using WebLocadora.Models;
using WebLocadora.Repository.Interface;

namespace WebLocadora.Repository
{
    public class FilmeRepository : Ifilme
    {
        private readonly AppDbContext _context;

        public FilmeRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Filme> Filmes => _context.Filmes.Include(f => f.FilmeCategoria);

        public IEnumerable<Filme> FilmesPreferidos => _context.Filmes.Where(f => f.Preferido).Include(c => c.FilmeCategoria);

        public Filme GetId(int FilmeId)
        {
            return _context.Filmes.FirstOrDefault(l => l.FilmeId == FilmeId);
        }
    }
    }