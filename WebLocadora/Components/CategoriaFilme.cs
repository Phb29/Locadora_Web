using Microsoft.AspNetCore.Mvc;
using WebLocadora.Repository.Interface;

namespace WebLocadora.Components
{
    public class CategoriaFilme : ViewComponent
    {
        private readonly IFilmeCategoria _filmeCategoria;

        public CategoriaFilme(IFilmeCategoria filmeCategoria)
        {
            _filmeCategoria = filmeCategoria;
        }

        public IViewComponentResult Invoke() { 
            var categori = _filmeCategoria.FilmeCategorias.OrderBy(f=>f.NomeGenero);
            return View(categori);
    }
}
}