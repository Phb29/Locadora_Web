using WebLocadora.Models;

namespace WebLocadora.Repository.Interface
{
    public interface IFilmeCategoria
    {
        public IEnumerable<FilmeCategoria> FilmeCategorias { get; }
    }
}
