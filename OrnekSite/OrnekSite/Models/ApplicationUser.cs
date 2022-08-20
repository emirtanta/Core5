using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrnekSite.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string PostaKodu { get; set; }

        [NotMapped]//orm araçlarında bir karşılığı olmadığını gösterir
        public string Role { get; set; }
    }
}
