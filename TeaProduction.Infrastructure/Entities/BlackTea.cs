namespace TeaProduction.Infrastructure.Entities
{
    public class BlackTea : Tea
    {
        public double CaffeineLevel { get; set; }
        public string Origin { get; set; }
        public int SteepingTime { get; set; }
        public override string GetDescription()
        {
            return $"Name: {Name}," +
                $" Type: {Type}," +
                $" Price: {Price}," +
                $" Caffeine level : {CaffeineLevel}," +
                $" Origin : {Origin}," +
                $" Steeping time : {SteepingTime}";
        }
    }
}
