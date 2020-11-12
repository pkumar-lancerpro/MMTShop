﻿using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models
{
    public class FeaturedProductRange
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int SKUMin { get; set; }

        [Required]
        public int SKUMax { get; set; }
    }
}
