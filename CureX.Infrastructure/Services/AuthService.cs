
using CureX.Backend.DTO;
using BCrypt.Net;
using System.Linq;
using CureX.Backend.DTO;
using CureX.Infrastructure.Data;
using CureX.Application.Contracts;

namespace CureX.Backend.Services
{
    public class AuthService:IAuthService
    {
        private readonly CureXDbContext _context;

        public AuthService(CureXDbContext context)
        {
            _context = context;
        }

        public Task<LoginResponse> Authenticate(LoginRequest request)
        {
            var user = _context.Users.SingleOrDefault(u => u.Role == request.role);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHashed))
                return Task.FromResult<LoginResponse>(null);
            return Task.FromResult(new LoginResponse
            {
                Role = user.Role
            });

        }



    }
}
