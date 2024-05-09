namespace TeaProduction.Business.DTOs
{
    public class BlackTeaDto : TeaBaseDto
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
