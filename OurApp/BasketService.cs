using System;
using OurApp.DiscountProviders;
using OurApp.Services;
using OurApp.Storages;

namespace OurApp
{
    public class BasketService
    {
        private readonly IBasketDataConnector _basketDataConnector;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductService _productService;
        private readonly DiscountProviderFactory _discountProviderFactory;

        public BasketService(
            IBasketDataConnector basketDataConnector,
            ICustomerRepository customerRepository,
            IProductService productService,
            DiscountProviderFactory discountProviderFactory)
        {
            _basketDataConnector = basketDataConnector;
            _customerRepository = customerRepository;
            _productService = productService;
            _discountProviderFactory = discountProviderFactory;
        }

        public BasketService() : this(
            new BasketDataConnectorAdapter(),
            new CustomerRepositoryAdapter(new CustomerRepository()), 
            new ProductServiceAdapter(new ProductService()),
            new DiscountProviderFactory(new DataTimeProvider()))
        {
        }

        public Basket GetBasketForCustomer(Guid customrId) => 
            _basketDataConnector.GetCustomerBasket(customrId) ?? CreateBasketForCustomer(customrId);

        private Basket CreateBasketForCustomer(Guid customerId)
        {
            var customer = _customerRepository.GetById(customerId) ?? throw new Exception("Customer doesnt exists!");
            
            var discount = _discountProviderFactory.Get(customer.CustomerType).GetDiscount(customer);

            var basket = new Basket
            {
                Id = Guid.NewGuid(),
                Customer = customer,
                CreatedAt = DateTime.Now,
                Discount = discount
            };

            _basketDataConnector.AddBasket(basket);

            return basket;
        }

        public bool AddProductToBasket(Guid basketId, Guid produtId)
        {
            var basket = _basketDataConnector.GetBasket(basketId);

            if (basket == null)
                return false;
            
            var product = _productService.GetById(produtId);

            if (product == null)
                return false;

            basket.Products.Add(product);
            
            return _basketDataConnector.Update(basket.Id, basket);
        }
    }
}