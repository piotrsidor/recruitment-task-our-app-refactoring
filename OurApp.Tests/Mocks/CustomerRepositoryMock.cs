using Moq;
using OurApp.Storages;

namespace OurApp.Tests.Mocks
{
    public class CustomerRepositoryMock : Mock<ICustomerRepository>
    {
        public CustomerRepositoryMock MockGetById(Customer customer)
        {
            Setup(x => x.GetById(customer.Id))
                .Returns(customer);

            return this;
        }
    }
}