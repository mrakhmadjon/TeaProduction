namespace TeaProduction.Infrastructure.Entities
{
    public class Customer : User
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPremium { get; set; }
    }
}
