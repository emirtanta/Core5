using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XCafeProject.Models
{
    //veritabanımızdaki AspUsers tablosuna ek özellikler eklemek için Identity tablosundan miras alınması gerektiği için tanımlandı
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
