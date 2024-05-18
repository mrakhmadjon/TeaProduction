using TeaProduction.Business.DTOs;
using TeaProduction.Infrastructure.Entities;

namespace TeaProduction.Business.TeaFactory
{
    public class GreenTeaFactory : TeaFactoryAbstract<GreenTeaDto>
    {

        public override GreenTeaDto GetTeaForReview()
        {
            return new GreenTeaDto()
            {
                Name = "Default Green Tea",
                Price = 5.99,
                AntioxidantLevel = 70.0,
                LeafGrade = "High",
                BrewingTemperature = 80,
                Type = "Green"
            };
        }
        public override void Produce(int countPackage)
        {
            Console.WriteLine($"Order has been given to factory. Green {countPackage} packages are being produced)");
        }
        public override string? GetSpecialPropertiesOfTea()
        {
            string teaProperties = $"{nameof(GreenTeaDto.BrewingTemperature)} {nameof(GreenTeaDto.LeafGrade)}, {nameof(GreenTeaDto.AntioxidantLevel)}";
            return $"Green Tea has these special properties {teaProperties}";
        }

        public override string? GetTheLocationOfTeaFactory()
        {
            return "Ukmergė District Municipality Ukmergės rajono savivaldybė Lithuania";
        }
    }
}
