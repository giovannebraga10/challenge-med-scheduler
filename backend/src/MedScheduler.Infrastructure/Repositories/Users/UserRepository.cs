using MedScheduler.Domain.Dtos;
using MedScheduler.Domain.Entities;
using MedScheduler.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedScheduler.Infrastructure.Repositories.Users
{
    public class UserRepository(AppDbContext _context) : IUserRepository
    {
        public async Task<User?> GetUserByIdAsync(Guid id) => await _context.Users.FindAsync(id);

        public async Task<List<DoctorDto>> GetDoctorsBySpecialityAsync(Guid specialityId) =>
           await _context.Users.Where(u => u.SpecialityId == specialityId)
                               .Select(x => new DoctorDto {
                                    Id = x.Id,
                                    Name = x.Name
                                }).ToListAsync();
        public Task AddUserAsync(User user) {
            _context.Users.AddAsync(user);
            return _context.SaveChangesAsync();
        }
    }
}
