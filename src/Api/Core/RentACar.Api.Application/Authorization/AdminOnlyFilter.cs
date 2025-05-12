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
        public class AdminOnlyFilter : IAsyncActionFilter
        {
            private readonly IAppUserRepository _appUserRepository;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public AdminOnlyFilter(IAppUserRepository appUserRepository, IHttpContextAccessor httpContextAccessor)
            {
                _appUserRepository = appUserRepository;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var httpContext = _httpContextAccessor.HttpContext;
                var userIdClaim = httpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out Guid userId))
                {
                    context.Result = new BadRequestObjectResult("UserId is missing or invalid");
                    return;
                }

                var user = await _appUserRepository.GetByIdAsync(userId);
                if (user == null || user.Status != Status.Admin)
                {
                    context.Result = new ForbidResult();
                    return;
                }

                await next(); // devam et
            }
        }

}
