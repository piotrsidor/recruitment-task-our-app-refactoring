using System;
using System.Collections.Generic;
using System.Linq;

namespace OurApp
{
    public class CustomerRepository
    {
        //
        // DO NOT CHANGE THIS FILE AT ALL!
        //
        private readonly List<Customer> _customers = new List<Customer>()
        {
            new Customer()
            {
                Id = new Guid("049247d8-f55e-4910-bf95-1d80152b8f99"), Name = "Robert", Number = "001",
                CustomerType = "regular", RegisteredAt = new DateTime(2020, 01, 10)
            },
            new Customer()
            {
                Id = new Guid("29922b9d-1309-4f5b-8476-c71546a456cb"), Name = "Anna", Number = "002",
                CustomerType = "special", RegisteredAt = new DateTime(2020, 06, 21)
            },
            new Customer()
            {
                Id = new Guid("31fd141a-4ec4-41ff-8d88-0eb081184872"), Name = "Kamil", Number = "003",
                CustomerType = "normal", RegisteredAt = new DateTime(2021, 03, 20)
            },
        };
        
        public Customer GetById(Guid customerId)
        {
            return _customers.FirstOrDefault(c => c.Id == customerId);
        }
    }
}
