using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core.Tokens;

namespace RentACar.Api.Application.Authorization
{
    /// <summary>
    /// Temel kullanıcı yetkilendirme kontrolü için öznitelik sınıfı.
    /// Kullanıcının kendi verilerine erişim yetkisini kontrol eder.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class OwnershipBaseUserAuthorization<TEntity>:Attribute,IAsyncActionFilter where TEntity :BaseUser, new()
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            HttpContext _context = context.HttpContext;

            // Kullanıcı ID'sini al
            var claimsList = _context.User.Claims.ToList();
            var userId = claimsList[0].Value;

            if (userId == null)
                throw new UnauthorizedAccessException("You are unauthorized!!!");

            Guid userId0 = Guid.Parse(userId);

            // Action parametrelerini kontrol et
            foreach (var argument in context.ActionArguments.Values)
            {
                var idProperty = argument?.GetType().GetProperty("Id");
                if (idProperty != null)
                {
                    var idValue = Guid.Parse(idProperty.GetValue(argument).ToString());
                    if (idValue != userId0)
                    {
                        throw new UnauthorizedAccessException("You are unauthorized!!!");
                    }
                }
            }

            // Yetkilendirme başarılı, işlemi devam ettir
            await next();
        }
    }
}
