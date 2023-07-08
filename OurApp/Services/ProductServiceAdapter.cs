using System;

namespace OurApp.Services
{
    public class ProductServiceAdapter : IProductService
    {
        private readonly ProductService _productService;

        public ProductServiceAdapter(
            ProductService productService)
        {
            _productService = productService;
        }

        public Product GetById(Guid productId) =>
            _productService.GetById(productId);
    }
}