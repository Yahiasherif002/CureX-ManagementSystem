
using CureX.Domain.Models;
using CureX.Infrastructure.Data;

public class DbSeeder
{
    private readonly CureXDbContext _context;

    public DbSeeder(CureXDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        // Check if users already exist to avoid duplication
        if (!_context.Users.Any())
        {
            // Seed Doctor and Receptionist users
            var doctor = new User
            {
                Username = "doctor@example.com",
                PasswordHashed = BCrypt.Net.BCrypt.HashPassword("Password123!"), // Hashed password
                Role = "Doctor"
            };
            var receptionist = new User
            {
                Username = "receptionist@example.com",
                PasswordHashed = BCrypt.Net.BCrypt.HashPassword("Password123!"), // Hashed password
                Role = "Receptionist"
            };

            _context.Users.AddRange(doctor, receptionist);

            // You can add more seeding for other entities (like patients, appointments, etc.)

            await _context.SaveChangesAsync();
        }
    }
}
