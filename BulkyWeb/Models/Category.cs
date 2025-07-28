using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
       
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Category Name")] // this is data anotation it will display category name instead on name
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
