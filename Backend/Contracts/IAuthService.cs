using CureX.Backend.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureX.Application.Contracts
{
    public interface IAuthService
    {
        Task<LoginResponse> Authenticate(LoginRequest request);
    }
}
