using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")] // this is data anotation it will display category name instead on name
        public string Name { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage ="Only 30 word are allowed")]
        public string Description { get; set; }
    }
}
