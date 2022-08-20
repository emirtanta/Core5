using System;
using System.ComponentModel.DataAnnotations;

namespace XCafeProject.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        
        public string Image { get; set; }
        public bool Onay { get; set; }

        [Required]
        public string Message { get; set; }
        public DateTime Tarih { get; set; }

    }
}
