using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductApiLibrary.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}