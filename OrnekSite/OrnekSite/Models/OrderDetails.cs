using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrnekSite.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]

        /* Sipariş ile Sipariş Detaylarını bağladık */
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public OrderHeader OrderHeader { get; set; }

        //Sipariş verilen ürünü getirir
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //sipariş verilen ürün adedi
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
