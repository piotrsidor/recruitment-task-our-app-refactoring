using System;

namespace OurApp.Services
{
    public interface IProductService
    {
        Product GetById(Guid productId);
    }
}