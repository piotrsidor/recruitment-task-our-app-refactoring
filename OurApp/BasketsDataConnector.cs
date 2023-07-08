using System;
using System.Collections.Generic;
using System.Linq;

namespace OurApp
{
    public static class BasketsDataConnector
    {
        //
        // DO NOT CHANGE THIS FILE AT ALL!
        //
        private static readonly List<Basket> _baskets = new List<Basket>();
        public static Basket GetCustomerBasket(Guid customrId)
        {
            return _baskets.FirstOrDefault(b => b.Customer.Id == customrId);
        }

        public static Basket GetBasket(Guid basketId)
        {
            return _baskets.FirstOrDefault(b => b.Id == basketId);
        }
        
        public static void AddBasket(Basket basket)
        {
            var customerBasket = _baskets.FirstOrDefault(b => b.Customer.Id == basket.Customer.Id);

            if (customerBasket != null)
                throw new BasketForCustomerExistsException(basket.Customer.Id);
            
            _baskets.Add(basket);
        }
        
        public static bool Update(Guid basketId, Basket basket)
        {
            var dbBasket = _baskets.FirstOrDefault(b => b.Id == basketId);

            if (dbBasket == null)
                throw new BasketNotExistsException(basket.Customer.Id);

            dbBasket.Products = basket.Products;

            return true;
        }

        public class BasketNotExistsException : Exception
        {
            public BasketNotExistsException(Guid basketId)
                : base($"Basket with Id {basketId} not exists.") { }
        }

        public class BasketForCustomerExistsException : Exception
        {
            public BasketForCustomerExistsException(Guid customerId) 
                : base($"Basket for customerId {customerId} exists.") { }
        }

    }
}