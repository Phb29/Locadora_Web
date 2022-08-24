using Microsoft.AspNetCore.Mvc;
using WebLocadora.Models;
using WebLocadora.ViewModel;

namespace WebLocadora.Components
{
    public class AluguelFilmeResumo:ViewComponent
    {
        private readonly AlugarFilme _alugarfilme;

        public AluguelFilmeResumo(AlugarFilme alugarFilme)
        {
            _alugarfilme = alugarFilme;
        }

        public IViewComponentResult Invoke()
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
    }

}
