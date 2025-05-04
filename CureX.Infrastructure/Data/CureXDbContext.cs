using Microsoft.EntityFrameworkCore;
using CureX.Domain;
using CureX.Domain.Models;

namespace CureX.Infrastructure.Data
{
    public class CureXDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Bill> Bills => Set<Bill>();

        public CureXDbContext(DbContextOptions<CureXDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Bill-Patient relationship to prevent cascade delete
            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Patient)
                .WithMany() // No navigation property in Patient class
                .HasForeignKey(b => b.PatientId)
                .OnDelete(DeleteBehavior.NoAction);  // Or DeleteBehavior.SetNull if you prefer

        
            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Patient)
                .WithMany()
                .HasForeignKey(b => b.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Appointment)
                .WithMany()
                .HasForeignKey(b => b.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);
        

           // Or DeleteBehavior.SetNull if needed

            base.OnModelCreating(modelBuilder);
        }
    }
}