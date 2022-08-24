using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebLocadora.Models
{
    public class Filme
    {


        [Key]
        public int FilmeId { get; set; }
        [StringLength(100)]
        [Display(Name = "Nome")]
        public string FilmeNome { get; set; }
        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }
        [Display(Name = "Disponível?")]
        public bool Disponivel { get; set; }


        public string FilmeImg { get; set; }

      



        [Display(Name = "Preferido?")]
        public bool Preferido { get; set; }

        public int FilmeCategoriaId { get; set; }
        public virtual FilmeCategoria FilmeCategoria { get; set; }
    }
}

