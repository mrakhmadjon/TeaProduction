using System.ComponentModel.DataAnnotations;

namespace TeaProduction.Business.DTOs
{
    public class TeaBaseDto
    {
        private double price;
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        [Required]
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
