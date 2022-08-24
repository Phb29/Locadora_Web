using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebLocadora.Models
{
    
    public class AlugarFilmeItem
    {
        public int AlugarFilmeItemId { get; set; }
        

        public int Quantidade { get; set; }

        
        public string AlugarFilmeId { get; set;}
        public Filme Filme { get; set; }

    }
}
