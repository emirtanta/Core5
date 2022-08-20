using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XCafeProject.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }



        [Required]
        [DisplayName("Menü Adı")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Menü Açıklama")]
        public string Description { get; set; }

        public string Image { get; set; }
        public bool Ozel { get; set; }

        [DisplayName("Menü Fiyat")]
        public double Price { get; set; }

        //Menü ile Kategori arasında 1'e çok işişki
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
