using System;

namespace OurApp.Storages
{
    public interface IBasketDataConnector
    {
        Basket GetCustomerBasket(Guid customerId);

        Basket GetBasket(Guid basketId);

        void AddBasket(Basket basket);

        bool Update(Guid basketId, Basket basket);
    }
}