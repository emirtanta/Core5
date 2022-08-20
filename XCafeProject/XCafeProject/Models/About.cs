using System.ComponentModel.DataAnnotations;

namespace XCafeProject.Models
{
    public class About
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
