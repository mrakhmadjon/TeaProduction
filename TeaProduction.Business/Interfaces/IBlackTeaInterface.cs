using TeaProduction.Business.DTOs;
using TeaProduction.Infrastructure.Entities;

namespace TeaProduction.Business.Interfaces
{
    public interface IBlackTeaInterface
    {
        public BlackTeaDto? Add(BlackTeaDto blackTea);
        public BlackTeaDto? Update(BlackTeaDto blackTea);
        public void Delete(int id);
        public BlackTeaDto GetById(int id);
        public IEnumerable<BlackTeaDto> GetAll();
    }
}
