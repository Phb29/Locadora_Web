using WebLocadora.Models;

namespace WebLocadora.ViewModel
{
    public class FilmeListaViewModel
    {
        public IEnumerable<Filme> Filmes { get; set; }
        public string Categoria { get; set; }


    }
}
