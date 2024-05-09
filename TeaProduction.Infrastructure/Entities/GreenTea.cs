namespace TeaProduction.Infrastructure.Entities
{
    internal class GreenTea : Tea
    {
        public double AntioxidantLevel { get; set; }
        public string LeafGrade { get; set; }
        public int BrewingTemperature { get; set; }
        public override string GetDescription()
        {
            return $"Name: {Name}," +
                $" Type: {Type}," +
                $" Price: {Price}, " +
                $"Antioxidant level : {AntioxidantLevel}," +
                $"Leaf grade: {LeafGrade}," +
                $"Brewing Temperature : {BrewingTemperature}";
        }
    }
}
