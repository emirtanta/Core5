using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrnekSite.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        /* kart ile kullanıcıyı bağladık */
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public string OrderStatus { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public string Semt { get; set; }
        [Required]
        public string Sehir { get; set; }
        [Required]
        public string PostaKodu { get; set; }

        //kullanıcının kart bilgilerini getirdik
        [Required]
        public string CartName { get; set; }
        [Required]
        public string CartNumber { get; set; }
        [Required]
        public string ExpirationMonth { get; set; }
        [Required]
        public string ExpirationYear { get; set; }
        [Required]
        public string Cvc { get; set; }
    }
}
