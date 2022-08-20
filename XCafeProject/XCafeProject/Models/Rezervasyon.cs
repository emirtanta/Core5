using System;
using System.ComponentModel.DataAnnotations;

namespace XCafeProject.Models
{
    public class Rezervasyon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string TelefonNo { get; set; }

        [Required]
        public int Sayi { get; set; } //kişi sayısı

        [Required]
        public string Saat { get; set; }

        [Required]
        public DateTime Tarih { get; set; }
    }
}
