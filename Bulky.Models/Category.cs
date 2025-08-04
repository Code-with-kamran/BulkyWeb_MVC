using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")] // this is data anotation it will display category name instead on name
        public string Name { get; set; }
        [Required]
        [Range(1,100)]
        [DisplayName("Display Order")] // this is data anotation it will display display order instead on displayorder
        public int DisplayOrder { get; set; }
    }
}
