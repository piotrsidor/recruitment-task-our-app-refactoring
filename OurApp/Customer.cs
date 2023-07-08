using System;

namespace OurApp
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string CustomerType { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}