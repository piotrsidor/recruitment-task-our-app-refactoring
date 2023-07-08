using System;
using System.Collections.Generic;
using System.Linq;

namespace OurApp
{
    public class ProductService
    {
        //
        // DO NOT CHANGE THIS FILE AT ALL!
        //
        private readonly List<Product> _products = new List<Product>()
        {
            new Product() { Id = new Guid("10cd6108-08f4-443a-91e0-82f88adf049b"), Name = "Bread", Price = 5m},
            new Product() { Id = new Guid("31d7d67a-4ccb-4b95-a81d-91458e63cc1c"), Name = "Milk", Price = 15m},
            new Product() { Id = new Guid("ff23274e-e276-4300-ae3f-7bed5492e183"), Name = "Water", Price = 3m},
            new Product() { Id = new Guid("8216c226-874f-4051-8ece-fa7462105539"), Name = "KitKat", Price = 25m},
        };
            
        public Product GetById(Guid productId)
        {
            return _products.FirstOrDefault(p => p.Id == productId);
        }
    }
}