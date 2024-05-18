using TeaProduction.Business.DTOs;
using TeaProduction.Infrastructure.Entities;

namespace TeaProduction.Business.TeaFactory
{
    public class HerbalTeaFactory : TeaFactoryAbstract<HerbalTeaDto>
    {
        public override HerbalTeaDto GetTeaForReview()
        {
            return new HerbalTeaDto()
            {
                Name = "Default Herbal Tea",
                Price = 6.99,
                Type = "Herbal",
                Ingredients = new List<string> { "Peppermint", "Chamomile" },
                HealthBenefits = "Calming, aids digestion",
                FlavorProfile = "Mild, floral"
            };
        }
        public override void Produce(int countPackage)
        {
            Console.WriteLine($"Order has been given to factory. Herbal {countPackage} packages are being produced)");
        }
        public override string? GetSpecialPropertiesOfTea()
        {
            string teaProperties = $"{nameof(HerbalTeaDto.Ingredients)} {nameof(HerbalTeaDto.HealthBenefits)}, {nameof(HerbalTeaDto.FlavorProfile)}";
            return $"Herbal Tea has these special properties {teaProperties}";
        }

        public override string? GetTheLocationOfTeaFactory()
        {
            return "Bümpliz-Oberbottigen Oberbottigen Bern Switzerland";
        }
    }
}
