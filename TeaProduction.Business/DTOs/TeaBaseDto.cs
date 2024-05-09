namespace TeaProduction.Business.DTOs
{
    public class TeaBaseDto
    {
        private double price;
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price {
            get { return price; }
            set { if (price >= 0) price = value; }
        }

        public virtual string GetDescription()
        {
            return $"Name: {Name}, Type: {Type}, Price: {Price}";
        }
    }
}
