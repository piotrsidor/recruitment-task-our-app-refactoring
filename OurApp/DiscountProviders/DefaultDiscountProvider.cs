namespace OurApp.DiscountProviders
{
    public class DefaultDiscountProvider : IDiscountProvider
    {
        public decimal GetDiscount(Customer customer) => 0m;
        public string Name => string.Empty;
    }
}