using System;
using System.Collections.Generic;

namespace OurApp
{
    public class Basket
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal Discount { get; set; }
    }
}