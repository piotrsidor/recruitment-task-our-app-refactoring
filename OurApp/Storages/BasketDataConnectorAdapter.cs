using System;

namespace OurApp.Storages
{
    public class BasketDataConnectorAdapter : IBasketDataConnector
    {
        public Basket GetCustomerBasket(Guid customerId) =>
            BasketsDataConnector.GetCustomerBasket(customerId);

        public Basket GetBasket(Guid basketId) =>
            BasketsDataConnector.GetBasket(basketId);

        public void AddBasket(Basket basket) =>
            BasketsDataConnector.AddBasket(basket);

        public bool Update(Guid basketId, Basket basket) =>
            BasketsDataConnector.Update(basketId, basket);
    }
}