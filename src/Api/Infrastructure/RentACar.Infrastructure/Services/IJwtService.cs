using RentACar.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Persistance.Services
{
    public interface IJwtService
    {
        string GenerateToken(BaseUser user);
        ClaimsPrincipal ValidateToken(string token);
    }
}
