using MedScheduler.Domain.Entities;

namespace MedScheduler.Domain.Interfaces
{
    public interface ISpecialityRepository
    {
        Task<IEnumerable<Speciality>> GetAllSpecialitiesAsync();
        Task<Speciality?> GetSpecialityByIdAsync(Guid id);
        Task AddSpecialityAsync(Speciality speciality);    
    }
}
