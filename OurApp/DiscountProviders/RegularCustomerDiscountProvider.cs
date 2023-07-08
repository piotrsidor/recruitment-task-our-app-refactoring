using OurApp.Services;

namespace OurApp.DiscountProviders
{
    public class RegularCustomerDiscountProvider : IDiscountProvider
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public RegularCustomerDiscountProvider(
            IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public decimal GetDiscount(Customer customer)
        {
            var registeredForDays = (_dateTimeProvider.Now - customer.RegisteredAt).TotalDays;
            return registeredForDays > 365 ? 0.2m : 0.1m;
        }

        public string Name => "regular";
    }
}