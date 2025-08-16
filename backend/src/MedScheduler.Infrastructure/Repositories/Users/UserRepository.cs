using MedScheduler.Domain.Entities;
using MedScheduler.Domain.Interfaces;

namespace MedScheduler.Infrastructure.Repositories.Users
{
    public class UserRepository(AppDbContext _context) : IUserRepository
    {
        public async Task<User?> GetUserByIdAsync(Guid id) => await _context.Users.FindAsync(id);
        public Task AddUserAsync(User user) {
            _context.Users.AddAsync(user);
            return _context.SaveChangesAsync();
        }
    }
}
