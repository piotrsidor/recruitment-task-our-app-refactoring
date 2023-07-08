using Moq;
using OurApp.Services;

namespace OurApp.Tests.Mocks
{
    public class ProductServiceMock : Mock<IProductService>
    {
        public ProductServiceMock MockGetById(Product product)
        {
            Setup(x => x.GetById(product.Id))
                .Returns(product);

            return this;
        }
    }
}