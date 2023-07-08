namespace OurApp.DiscountProviders
{
    public class SpecialCustomerDiscountProvider : IDiscountProvider
    {
        public decimal GetDiscount(Customer customer) => 0.25m;
        
        public string Name => "special";
    }
}