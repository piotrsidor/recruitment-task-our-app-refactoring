using System;

namespace OurApp.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // DO NOT CHANGE THIS FILE AT ALL!
            //     
            var customerId = new Guid("29922b9d-1309-4f5b-8476-c71546a456cb");
            var productId = new Guid("10cd6108-08f4-443a-91e0-82f88adf049b");
            
            var basketService = new BasketService();
            var basket = basketService.GetBasketForCustomer(customerId);
            
            var result = basketService.AddProductToBasket(basket.Id, productId);
            Console.WriteLine($"Product with id: {productId} was added to basket ({basket.Id}. Result: {result})");
        }
    }
}