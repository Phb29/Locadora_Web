using System.ComponentModel.DataAnnotations;


namespace WebLocadora.Models
{
    public class FilmeCategoria
    {
        [Key]
        public int FilmeCategoriaId { get; set; }
        [Display(Name = "Gênero")]
        public string NomeGenero { get; set; }
        
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<Filme> Filme { get; set; }
    }
}
