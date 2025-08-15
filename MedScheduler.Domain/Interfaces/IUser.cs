using MedScheduler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedScheduler.Domain.Interfaces
{
    public interface IUser
    {
        Task<User?> GetUserByIdAsync(Guid id);
        Task AddUserAsync(User user);

    }
}
