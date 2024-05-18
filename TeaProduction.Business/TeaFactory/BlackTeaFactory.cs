using TeaProduction.Business.DTOs;

namespace TeaProduction.Business.TeaFactory
{
    public class BlackTeaFactory : TeaFactoryAbstract<BlackTeaDto>
    {

        public override BlackTeaDto GetTeaForReview()
        {
            return new BlackTeaDto()
            {
                Name = "Lapsang Souchong",
                Type = "Black",
                CaffeineLevel = 40.0,
                Origin = "Poland",
                SteepingTime = 4,
                Price = 13.50
            };
        }
        public override void Produce(int countPackage)
        {
            Console.WriteLine($"Order has been given to factory. BlackTea {countPackage} packages are being produced)");
        }
        public override string? GetSpecialPropertiesOfTea()
        {
            string teaProperties = $"{nameof(BlackTeaDto.CaffeineLevel)} {nameof(BlackTeaDto.SteepingTime)}, {nameof(BlackTeaDto.Origin)}";
            return $"Black Tea has these special properties {teaProperties}";
        }

        public override string? GetTheLocationOfTeaFactory()
        {
            return "Łódź Voivodeship Województwo łódzkie Poland";
        }
    }
}
