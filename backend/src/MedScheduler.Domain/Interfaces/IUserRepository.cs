using MedScheduler.Domain.Dtos;
using MedScheduler.Domain.Entities;

namespace MedScheduler.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(Guid id);
        Task AddUserAsync(User user);
        Task<List<DoctorDto>> GetDoctorsBySpecialityAsync(Guid specialityId);

    }
}
