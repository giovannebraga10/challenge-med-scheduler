using MedScheduler.Domain.Entities;
using MedScheduler.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedScheduler.Infrastructure.Repositories.Specialities
{
    public class SpecialityRepository(AppDbContext _context) : ISpecialityRepository
    {
        public async Task<IEnumerable<Speciality>> GetAllSpecialitiesAsync() => await _context.Specialities.ToListAsync();

        public async Task<Speciality?> GetSpecialityByIdAsync(Guid id) => await _context.Specialities.FindAsync(id);

        public Task AddSpecialityAsync(Speciality speciality)
        {
            _context.Specialities.AddAsync(speciality);
            return _context.SaveChangesAsync();
        }
    }
}
    