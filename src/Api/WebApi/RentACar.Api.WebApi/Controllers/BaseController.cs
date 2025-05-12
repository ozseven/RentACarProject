using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RentACar.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase  // Tüm controllerlar için temel sınıf
    {
        public Guid? UserId  // JWT'den kullanıcı ID'sini çeker
        {
            get
            {
                var val = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                return val is null ? null : new Guid(val);  // ID yoksa null, varsa Guid döndür
            }
        }
    }
}
