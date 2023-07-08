using System;

namespace OurApp
{
    public class BasketService
    {
        public Basket GetBasketForCustomer(Guid customrId)
        {
            Basket basket = BasketsDataConnector.GetCustomerBasket(customrId);

            if (basket != null)
                return basket;
                
            var customerRepository = new CustomerRepository();
            Customer customer = customerRepository.GetById(customrId);

            if (customer == null)
                throw new Exception("Customer doesnt exists!");

            decimal discount = 0m;
            var now = DateTime.Now;
            var registeredForDays = (now - customer.RegisteredAt).TotalDays;
            
            if (customer.CustomerType == "regular")
            {
                if (registeredForDays > 365)
                    discount = 0.2m;
                else
                    discount = 0.1m;
            } else if (customer.CustomerType == "special")
            {
                discount = 0.25m;
            }
            
            basket = new Basket()
            {
                Id = Guid.NewGuid(),
                Customer = customer,
                CreatedAt = DateTime.Now,
                Discount = discount
            };
            
            BasketsDataConnector.AddBasket(basket);

            return basket;
        }

        public bool AddProductToBasket(Guid basketId, Guid produtId)
        {
            Basket basket = BasketsDataConnector.GetBasket(basketId);

            if (basket == null)
                return false;
            
            var productService = new ProductService();
            var product = productService.GetById(produtId);

            if (product == null)
                return false;

            basket.Products.Add(product);

            var result = BasketsDataConnector.Update(basket.Id, basket);

            return result;
        }
    }
}
