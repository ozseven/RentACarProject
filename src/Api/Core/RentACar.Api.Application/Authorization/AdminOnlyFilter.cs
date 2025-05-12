using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Authorization
{
    /// <summary>
    /// Bu filtre, sadece Admin statüsüne sahip kullanıcıların erişimine izin veren bir action filtresidir.
    /// Kullanıcının kimlik doğrulama durumunu ve admin yetkilerini kontrol eder.
    /// </summary>
    public class AdminOnlyFilter : IAsyncActionFilter  // Admin yetkisi kontrolü yapan filtre
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// AdminOnlyFilter sınıfının yeni bir örneğini gerekli bağımlılıklarla başlatır.
        /// </summary>
        /// <param name="appUserRepository">Kullanıcı verilerine erişim için repository</param>
        /// <param name="httpContextAccessor">Mevcut kullanıcı bilgilerini almak için HTTP context erişimcisi</param>
        public AdminOnlyFilter(IAppUserRepository appUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _appUserRepository = appUserRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Action metodundan önce çalışarak admin yetkilerini doğrular.
        /// Kullanıcının kimliğinin doğruluğunu ve admin statüsünü kontrol eder.
        /// </summary>
        /// <param name="context">Action çalıştırma bağlamı</param>
        /// <param name="next">Sonraki action çalıştırma delegesi</param>
        /// <returns>Kullanıcı ID'si geçersizse BadRequest, admin değilse Forbid, yetkiliyse işleme devam eder</returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var userIdClaim = httpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;  // Kullanıcı ID'sini claims'den al

            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out Guid userId))
            {
                context.Result = new BadRequestObjectResult("Kullanıcı ID'si eksik veya geçersiz");
                return;
            }

            var user = await _appUserRepository.GetByIdAsync(userId);
            if (user == null || user.Status != Status.Admin)  // Admin kontrolü
            {
                context.Result = new ForbidResult();
                return;
            }

            await next();  // Yetki varsa devam et
        }
    }
}
