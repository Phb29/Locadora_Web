using WebLocadora.Context;
using WebLocadora.Models;
using WebLocadora.Repository.Interface;

namespace WebLocadora.Repository
{
    public class FilmeCategoriaRepository : IFilmeCategoria
    {


        private readonly AppDbContext _appDbContext;

        public FilmeCategoriaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<FilmeCategoria> FilmeCategorias => _appDbContext.FilmeCategorias;

        
    }

}
