using Microsoft.AspNetCore.Mvc;
using WebLocadora.Context;
using WebLocadora.Models;
using WebLocadora.Repository.Interface;
using WebLocadora.ViewModel;

namespace WebLocadora.Controllers
{
    public class FilmeController : Controller
    {
        private readonly Ifilme _filme;

        public FilmeController(Ifilme context)
        {
            _filme = context;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Filme> filmes;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                filmes = _filme.Filmes.OrderBy(f => f.FilmeId);
                categoriaAtual = "todos filmes";
            }
              else
            {
            //  if (string.Equals("comédia", categoria, StringComparison.OrdinalIgnoreCase))
            //  {
            //  filmes = _filme.Filmes.Where(f => f.FilmeCategoria
            //         .NomeGenero.Equals("comédia")).OrderBy(f => f.FilmeNome);

            //  }
            //    else
            //  {


            //  filmes = _filme.Filmes.Where(f => f.FilmeCategoria.
            //  NomeGenero.Equals("Terror")).OrderBy(f => f.FilmeNome);
            //  }
            filmes = _filme.Filmes.Where(f=>f.FilmeCategoria.NomeGenero.Equals
            (categoria));

            categoriaAtual = categoria;
                }
                
                var filmeListaViewModel = new FilmeListaViewModel
                {
                    Filmes=filmes,
                    Categoria =categoriaAtual
                };
                return View(filmeListaViewModel);






            }
        public IActionResult Detale(int FilmeId)
        { 
            var detalhes = _filme.Filmes.FirstOrDefault(f => f.FilmeId == FilmeId);

            return View(detalhes);

        }
        public ViewResult Search(string searchString)
        {
            IEnumerable<Filme> filmes;
            string categoriaAtual = string.Empty;

                if (string.IsNullOrEmpty(searchString))
            {
                filmes= _filme.Filmes.OrderBy(f => f.FilmeId);
                categoriaAtual = "todas os filmes";
            }
            else
            {
                filmes = _filme.Filmes.Where(f => f.FilmeNome.ToLower().Contains(searchString.ToLower()));



                if (filmes.Any())
                
                    categoriaAtual = "Filmes";
                
                else
                
                    categoriaAtual = "Nenhum Filme encontrado";

                }
                return View("~/Views/Filme/List.cshtml" , new FilmeListaViewModel{
                    Filmes=filmes,
                        Categoria=categoriaAtual
                }) ;
            }
        


        }





        }
    
