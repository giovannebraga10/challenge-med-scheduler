using MedScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedScheduler.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Speciality> Specialities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name).HasMaxLength(100);
                entity.Property(u => u.Email).HasMaxLength(100);
                entity.Property(u => u.PasswordHash);
                entity.Property(u => u.Role);
                entity.Property(u => u.CreatedAt);
                entity.Property(u => u.SpecialityId);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(a => a.PatientId);
                entity.Property(a => a.DoctorId);
                entity.Property(a => a.IsAvailable);
                entity.Property(a => a.AppointmentDate);
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(20);
            });
        }

    }
}
