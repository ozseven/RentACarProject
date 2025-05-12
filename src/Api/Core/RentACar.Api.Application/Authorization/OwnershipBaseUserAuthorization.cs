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
    public class OwnershipBaseUserAuthorization<TEntity>:Attribute,IAsyncActionFilter where TEntity :BaseUser, new()  // Kullanıcının kendi verilerine erişim yetkisini kontrol eden filtre
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            HttpContext _context = context.HttpContext;

            var claimsList = _context.User.Claims.ToList();
            var userId = claimsList[0].Value;  // Kullanıcı ID'sini claims'den al

            if (userId == null)
                throw new UnauthorizedAccessException("You are unauthorized!!!");

            Guid userId0 = Guid.Parse(userId);

            foreach (var argument in context.ActionArguments.Values)  // Action parametrelerindeki ID'leri kontrol et
            {
                var idProperty = argument?.GetType().GetProperty("Id");
                if (idProperty != null)
                {
                    var idValue = Guid.Parse(idProperty.GetValue(argument).ToString());
                    if (idValue != userId0)  // ID'ler eşleşmiyorsa yetkisiz erişim
                    {
                        throw new UnauthorizedAccessException("You are unauthorized!!!");
                    }
                }
            }

            await next();  // Yetki varsa devam et
        }
    }
}
