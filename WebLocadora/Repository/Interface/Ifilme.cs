using WebLocadora.Models;

namespace WebLocadora.Repository.Interface
{
    public interface Ifilme
    {
        public IEnumerable<Filme> Filmes { get; }
        public IEnumerable<Filme> FilmesPreferidos { get; }
        Filme GetId(int FilmeId);




    }
}