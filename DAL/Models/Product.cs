using DAL.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Count { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
