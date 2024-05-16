using TeaProduction.Business.DTOs;
using TeaProduction.Business.Interfaces;

namespace TeaProduction.Business.Services
{
    public class FakeBlackTeaService : IBlackTeaInterface
    {
        private readonly List<BlackTeaDto> blackTeaList;

        public FakeBlackTeaService()
        {
            this.blackTeaList = new List<BlackTeaDto>()

                {
                     new BlackTeaDto
            {
                Id = 1,
                Name = "Darjeeling",
                Type = "Black",
                CaffeineLevel = 50.0,
                Origin = "India",
                SteepingTime = 5,
                Price = 12.99
            },
            new BlackTeaDto
            {
                Id = 2,
                Name = "Assam",
                Type = "Black",
                CaffeineLevel = 60.0,
                Origin = "India",
                SteepingTime = 4,
                Price = 10.50
            },
            new BlackTeaDto
            {
                Id = 3,
                Name = "Earl Grey",
                Type = "Black",
                CaffeineLevel = 55.0,
                Origin = "China",
                SteepingTime = 3,
                Price = 14.75
            },
            new BlackTeaDto
            {
                Id = 4,
                Name = "English Breakfast",
                Type = "Black",
                CaffeineLevel = 65.0,
                Origin = "Various",
                SteepingTime = 5,
                Price = 11.00
            },
            new BlackTeaDto
            {
                Id = 5,
                Name = "Lapsang Souchong",
                Type = "Black",
                CaffeineLevel = 40.0,
                Origin = "China",
                SteepingTime = 4,
                Price = 13.50
            }
                }
            ;
        }
        public BlackTeaDto? Add(BlackTeaDto blackTea)
        {
            blackTea.Id = 5 * Random.Shared.Next(1);
            blackTeaList.Add(blackTea);
            return blackTea;
        }

        public void Delete(int id)
        {
           blackTeaList.Remove(blackTeaList.FirstOrDefault(x => x.Id == id));
        }

        public IEnumerable<BlackTeaDto> GetAll()
        {
           return blackTeaList;
        }

        public BlackTeaDto GetById(int id)
        {
            return blackTeaList.Find(p => p.Id == id);
        }

        public BlackTeaDto? Update(BlackTeaDto blackTea)
        {
            var oldTea = blackTeaList.Find(p => p.Id == blackTea.Id);

            oldTea.CaffeineLevel = blackTea.CaffeineLevel;
            oldTea.SteepingTime = blackTea.SteepingTime;
            oldTea.Price = blackTea.Price;

            return oldTea;
        }
    }
}
