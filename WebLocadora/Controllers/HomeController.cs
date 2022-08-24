using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebLocadora.Models;
using WebLocadora.Repository.Interface;
using WebLocadora.ViewModel;

namespace WebLocadora.Controllers
{
    public class HomeController : Controller
    {
        

       
        private readonly Ifilme _filme;

        public HomeController(Ifilme filme)
        {
            _filme = filme;
        }

        public IActionResult Index()
        {
            var filme = new HomeViewModel
            {
                FilmesPreferidos = _filme.FilmesPreferidos

        };
            
            return View(filme);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}