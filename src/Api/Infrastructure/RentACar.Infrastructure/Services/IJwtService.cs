using RentACar.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Persistance.Services
{
    public interface IJwtService  // JWT işlemleri için servis arayüzü
    {
        string GenerateToken(BaseUser user);  // Kullanıcıdan JWT üret
        ClaimsPrincipal ValidateToken(string token);  // Token'ı doğrula ve claimleri döndür
    }
}
