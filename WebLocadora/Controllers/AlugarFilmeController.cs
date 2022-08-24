using Microsoft.AspNetCore.Mvc;
using WebLocadora.Models;
using WebLocadora.Repository.Interface;
using WebLocadora.ViewModel;

namespace WebLocadora.Controllers
{
    public class AlugarFilmeController : Controller
    {
        private readonly Ifilme _filme;
        private readonly AlugarFilme _alugarfilme;

        public AlugarFilmeController(Ifilme filme, AlugarFilme alugarfilme)
        {
            _filme = filme;
            _alugarfilme = alugarfilme;
        }

        public IActionResult Index()
        {
            var itens = _alugarfilme.GetAlugarFilmeItems();
            _alugarfilme.AlugarFilmeItems = itens;

            var alugarfilmeview = new AlugarFilmeViewModel
            {
                AlugarFilme = _alugarfilme,
                AlugarFilmeTotal = _alugarfilme.CompraTotal()

            };
            return View(alugarfilmeview);
        }
            public IActionResult AdicionarItemNoCarrinhoCompra(int FilmeId)
            {
                var lancheSelecionado = _filme.Filmes
                                        .FirstOrDefault(p => p.FilmeId == FilmeId);

                if (lancheSelecionado != null)
                {
                _alugarfilme.AdicionarFilme(lancheSelecionado);
                }
                return RedirectToAction("Index");
            }


            public IActionResult RemoverItemDoCarrinhoCompra(int FilmeId)
            {
                var lancheSelecionado = _filme.Filmes
                                        .FirstOrDefault(p => p.FilmeId == FilmeId);

                if (lancheSelecionado != null)
                {
                    _alugarfilme.RemoverFilme(lancheSelecionado);
                }
                return RedirectToAction("Index");
            }
        }
    }

