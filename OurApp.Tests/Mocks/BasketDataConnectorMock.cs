using System;
using Moq;
using OurApp.Storages;

namespace OurApp.Tests.Mocks
{
    public class BasketDataConnectorMock : Mock<IBasketDataConnector>
    {
        public BasketDataConnectorMock MockGetCustomerBasket(Guid customerId, Basket basket)
        {
            Setup(x => x.GetCustomerBasket(customerId))
                .Returns(basket);

            return this;
        }

        public BasketDataConnectorMock MockGetBasket(Basket basket)
        {
            Setup(x => x.GetBasket(basket.Id))
                .Returns(basket);

            return this;
        }

        public BasketDataConnectorMock MockUpdate(Basket basket)
        {
            Setup(x => x.Update(basket.Id, basket))
                .Returns(true);

            return this;
        }
    }
}