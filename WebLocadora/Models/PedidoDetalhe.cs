using System.ComponentModel.DataAnnotations.Schema;

namespace WebLocadora.Models
{
    public class PedidoDetalhe
    {
        public int PedidoDetalheId { get; set; }
        public int PedidoId { get; set; }
        public int FilmeId { get; set; }    
        public int Qunatidade { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        public virtual Filme Filme { get; set; }
        public virtual Pedido  Pedido { get; set; }
 


    }
}
