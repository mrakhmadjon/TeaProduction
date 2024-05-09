namespace TeaProduction.Infrastructure.Entities
{
    internal class HerbalTea : Tea
    {
        public List<string> Ingredients { get; set; }
        public string HealthBenefits { get; set; }
        public string FlavorProfile { get; set; }
        public override string GetDescription()
        {
            return $"Name: {Name}," +
                $" Type: {Type}," +
                $" Price: {Price}," +
                $"Ingredients count : {Ingredients.Capacity}," +
                $"Health benefits: {HealthBenefits}," +
                $"Flavor profile: {FlavorProfile}";
        }
    }
}
