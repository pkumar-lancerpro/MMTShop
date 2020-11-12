using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int SKU { get; set; }

        [Required]
        public string Name  { get; set; }
        public string Description  { get; set; }

        public decimal Price  { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        public virtual Category  Category { get; set; }
    }
}
