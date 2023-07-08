using System.Collections.Generic;
using System.Linq;
using OurApp.Services;

namespace OurApp.DiscountProviders
{
    public class DiscountProviderFactory
    {
        private readonly IEnumerable<IDiscountProvider> _discountProviders;

        public DiscountProviderFactory(
            IDateTimeProvider dateTimeProvider)
        {
            _discountProviders = new IDiscountProvider[]
            {
                new RegularCustomerDiscountProvider(dateTimeProvider), 
                new SpecialCustomerDiscountProvider()
            };
        }

        public IDiscountProvider Get(string customerType) =>
            _discountProviders.FirstOrDefault(x => x.Name == customerType) ?? new DefaultDiscountProvider();
    }
}