namespace TeaProduction.Infrastructure.Entities
{
    public class Tea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }

        public virtual string GetDescription()
        {
            return $"Name: {Name}, Type: {Type}, Price: {Price}";
        }
    }
}
