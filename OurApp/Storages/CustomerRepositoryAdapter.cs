using System;

namespace OurApp.Storages
{
    public class CustomerRepositoryAdapter : ICustomerRepository
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerRepositoryAdapter(
            CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetById(Guid customerId) =>
            _customerRepository.GetById(customerId);
    }
}