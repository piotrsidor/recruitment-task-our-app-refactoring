namespace OurApp.DiscountProviders
{
    public interface IDiscountProvider
    {
        public decimal GetDiscount(Customer customer);

        public string Name { get; }
    }
}