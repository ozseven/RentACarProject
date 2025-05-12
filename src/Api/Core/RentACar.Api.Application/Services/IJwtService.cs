using RentACar.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Core.RentACar.Api.Application.Services
{
    /// <summary>
    /// JWT (JSON Web Token) işlemleri için servis arayüzü.
    /// Token üretimi ve token doğrulama işlemlerini tanımlar.
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        /// Belirtilen kullanıcı için bir JWT oluşturur.
        /// </summary>
        /// <param name="user">Token oluşturulacak kullanıcı.</param>
        /// <returns>Oluşturulan JWT.</returns>
        string GenerateToken(BaseUser user);

        /// <summary>
        /// Verilen bir JWT'yi doğrular ve token içindeki talepleri (claims) döndürür.
        /// </summary>
        /// <param name="token">Doğrulanacak JWT.</param>
        /// <returns>Token geçerliyse, token içindeki talepleri içeren ClaimsPrincipal; aksi takdirde null.</returns>
        ClaimsPrincipal ValidateToken(string token);
    }
}
