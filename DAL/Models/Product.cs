using DAL.Base;
using System;

namespace DAL.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
