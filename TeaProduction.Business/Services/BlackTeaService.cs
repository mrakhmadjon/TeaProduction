using TeaProduction.Business.DTOs;
using TeaProduction.Business.Interfaces;
using TeaProduction.Infrastructure.Entities;

namespace TeaProduction.Business.Services
{
    public class BlackTeaService : IBlackTeaInterface
    {
        private readonly IRepositoryInterface<BlackTea> repositoryInterface;
        private readonly ILoggerInterface loggerInterface;

        public BlackTeaService(IRepositoryInterface<BlackTea> repositoryInterface,
            ILoggerInterface loggerInterface)
        {
            this.repositoryInterface = repositoryInterface;
            this.loggerInterface = loggerInterface;
        }
        public BlackTeaDto? Add(BlackTeaDto blackTea)
        {
            try
            {
                BlackTea blackTeaEntity = new BlackTea
                {
                    Name = blackTea.Name,
                    CaffeineLevel = blackTea.CaffeineLevel,
                    Origin = blackTea.Origin,
                    Price = blackTea.Price,
                    SteepingTime = blackTea.SteepingTime,
                    Type = blackTea.Type
                };

                repositoryInterface.Add(blackTeaEntity);
                blackTea.Id = blackTeaEntity.Id;
                loggerInterface.Log("Black tea was successfully added to the database", Enums.LogLevel.Information);
                return blackTea;
            }
            catch (Exception ex)
            {
                loggerInterface.Log(ex, "Error in inserting black tea to the database");
                return null;
            }
        }

        public void Delete(int id)
        {
            var blackTeaEntity = repositoryInterface.GetAll(p => p.Id == id).FirstOrDefault();
            if (blackTeaEntity is null)
            {
                loggerInterface.Log("Black tea does not exist in the database", Enums.LogLevel.Warning);
                return;
            }
            repositoryInterface.DeleteAsync(blackTeaEntity).GetAwaiter();
        }

        public IEnumerable<BlackTeaDto> GetAll()
        {
            var blackTeaEntity = repositoryInterface.GetAll();
            IList<BlackTeaDto> blackTeas = new List<BlackTeaDto>();
            foreach (var entity in blackTeaEntity)
            {
                blackTeas.Add(new BlackTeaDto()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    CaffeineLevel = entity.CaffeineLevel,
                    Origin = entity.Origin,
                    Price = entity.Price,
                    SteepingTime = entity.SteepingTime,
                    Type = entity.Type
                });
            }
            return blackTeas;
        }

        public BlackTeaDto GetById(int id)
        {
            var blackTeaEntity = repositoryInterface.GetAll(p => p.Id == id).FirstOrDefault();
            BlackTeaDto blackTeaDto = new BlackTeaDto
            {
                Id = blackTeaEntity.Id,
                CaffeineLevel = blackTeaEntity.CaffeineLevel,
                Name = blackTeaEntity.Name,
                Origin = blackTeaEntity.Origin,
                Price = blackTeaEntity.Price,
                SteepingTime = blackTeaEntity.SteepingTime,
                Type = blackTeaEntity.Type
            };
            return blackTeaDto;
        }

        public BlackTeaDto? Update(BlackTeaDto blackTea)
        {
            try
            {
                BlackTea blackTeaEntity = new BlackTea
                {
                    Name = blackTea.Name,
                    CaffeineLevel = blackTea.CaffeineLevel,
                    Origin = blackTea.Origin,
                    Price = blackTea.Price,
                    SteepingTime = blackTea.SteepingTime,
                    Type = blackTea.Type
                };

                repositoryInterface.UpdateAsync(blackTeaEntity).GetAwaiter();

                loggerInterface.Log("Black tea was successfully updated to the database", Enums.LogLevel.Information);
                return blackTea;
            }
            catch (Exception ex)
            {
                loggerInterface.Log(ex, "Error in updating black tea to the database");
                return null;
            }
        }
    }
}
