using System;

namespace OurApp.Storages
{
    public interface ICustomerRepository
    {
        Customer GetById(Guid customerId);
    }
}