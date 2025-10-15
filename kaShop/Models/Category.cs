using System.ComponentModel.DataAnnotations;

namespace kaShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MinLength(3)]
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
        
        public List<Product>? Products { get; set; }
}
}
