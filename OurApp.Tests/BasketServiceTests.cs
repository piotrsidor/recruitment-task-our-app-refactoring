using System;
using AutoFixture;
using FluentAssertions;
using Moq;
using OurApp.DiscountProviders;
using OurApp.Tests.Mocks;
using Xunit;

namespace OurApp.Tests
{
    public class BasketServiceTests
    {
        private readonly IFixture _fixture = new Fixture();


        [Fact]
        public void GetBasketForCustomer_WhenBasketExists_ThenReturnsBasket()
        {
            var customer = _fixture.Create<Customer>();
            var basket = _fixture.Build<Basket>().With(x => x.Customer, customer).Create();

            var basketDataConnector = new BasketDataConnectorMock().MockGetCustomerBasket(customer.Id, basket).Object;
            var customerRepository = new CustomerRepositoryMock().Object;
            var productService = new ProductServiceMock().Object;
            var dateTimeProvider = new DateTimeProviderMock().Object;

            var service = new BasketService(basketDataConnector, customerRepository, productService, new DiscountProviderFactory(dateTimeProvider));

            var results = service.GetBasketForCustomer(customer.Id);

            results.Should().Be(basket);
        }

        [Fact]
        public void GetBasketForCustomer_WhenCustomerDoesNotExists_ThenThrowsException()
        {
            var customer = _fixture.Create<Customer>();
            
            var basketDataConnector = new BasketDataConnectorMock().Object;
            var customerRepository = new CustomerRepositoryMock().Object;
            var productService = new ProductServiceMock().Object;
            var dateTimeProvider = new DateTimeProviderMock().Object;

            var service = new BasketService(basketDataConnector, customerRepository, productService, new DiscountProviderFactory(dateTimeProvider));

            var act = new Func<Basket>(() => service.GetBasketForCustomer(customer.Id));

            act.Should().Throw<Exception>();
        }

        [Theory]
        [InlineData("regular", -100, 0.1)]
        [InlineData("regular", -400, 0.2)]
        [InlineData("special", -100, 0.25)]
        public void GetBasketForCustomer_WhenGivenCustomerTypeAndDaysFromRegistration_ThenReturnsBasketWithCorrectDiscount(
            string customerType, 
            int numberOfDaysFromRegistration, 
            decimal expectedDiscount)
        {
            var dateTimeProvider = new DateTimeProviderMock().MockNow().Object;
            
            var customer = _fixture.Build<Customer>()
                .With(x => x.CustomerType, customerType)
                .With(x => x.RegisteredAt, dateTimeProvider.Now.AddDays(numberOfDaysFromRegistration))
                .Create();
            
            var basketDataConnector = new BasketDataConnectorMock().Object;
            var customerRepository = new CustomerRepositoryMock().MockGetById(customer).Object;
            var productService = new ProductServiceMock().Object;
            
            
            var service = new BasketService(basketDataConnector, customerRepository, productService, new DiscountProviderFactory(dateTimeProvider));

            var result = service.GetBasketForCustomer(customer.Id);

            result.Discount.Should().Be(expectedDiscount);
        }

        [Fact]
        public void AddProductToBasket_WhenBasketAndProductExists_ThenUpdateBasketAndReturnsTrue()
        {
            var basket = _fixture.Create<Basket>();
            var product = _fixture.Create<Product>();
            
            var basketDataConnector = new BasketDataConnectorMock()
                .MockGetBasket(basket)
                .MockUpdate(basket).Object;
            var customerRepository = new CustomerRepositoryMock().Object;
            var productService = new ProductServiceMock().MockGetById(product).Object;
            var dateTimeProvider = new DateTimeProviderMock().Object;
            
            var service = new BasketService(basketDataConnector, customerRepository, productService, new DiscountProviderFactory(dateTimeProvider));

            var result = service.AddProductToBasket(basket.Id, product.Id);

            result.Should().Be(true);
            Mock.Get(basketDataConnector).Verify(x => x.Update(basket.Id, basket), Times.Once);
        }

        [Fact]
        public void AddProductToBasket_WhenBasketNotExists_ThenReturnTrue()
        {
            var basket = _fixture.Create<Basket>();
            var product = _fixture.Create<Product>();
            
            var basketDataConnector = new BasketDataConnectorMock().Object;
            var customerRepository = new CustomerRepositoryMock().Object;
            var productService = new ProductServiceMock().Object;
            var dateTimeProvider = new DateTimeProviderMock().Object;
            
            var service = new BasketService(basketDataConnector, customerRepository, productService, new DiscountProviderFactory(dateTimeProvider));
            
            var result = service.AddProductToBasket(basket.Id, product.Id);
            
            result.Should().Be(false);
            Mock.Get(basketDataConnector).Verify(x => x.Update(basket.Id, basket), Times.Never);
        }
        
        [Fact]
        public void AddProductToBasket_WhenBasketExistsButProductNotExists_ThenReturnTrue()
        {
            var basket = _fixture.Create<Basket>();
            var product = _fixture.Create<Product>();
            
            var basketDataConnector = new BasketDataConnectorMock().MockGetBasket(basket).Object;
            var customerRepository = new CustomerRepositoryMock().Object;
            var productService = new ProductServiceMock().Object;
            var dateTimeProvider = new DateTimeProviderMock().Object;
            
            var service = new BasketService(basketDataConnector, customerRepository, productService, new DiscountProviderFactory(dateTimeProvider));
            
            var result = service.AddProductToBasket(basket.Id, product.Id);
            
            result.Should().Be(false);
            Mock.Get(basketDataConnector).Verify(x => x.Update(basket.Id, basket), Times.Never);
        }
        
    }
}