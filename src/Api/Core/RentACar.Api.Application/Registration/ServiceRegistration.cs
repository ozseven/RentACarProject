using Microsoft.Extensions.DependencyInjection;
using RentACar.Api.Application.Authorization;
using RentACar.Api.Application.Mapping;
using RentACar.Api.Core.RentACar.Api.Application.Services;
using RentACar.Infrastructure.Persistance.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Registration
{
    /// <summary>
    /// Uygulama servislerinin DI container'a kaydedilmesi için yardımcı sınıf.
    /// MediatR, AutoMapper ve JWT servislerinin yapılandırmasını sağlar.
    /// </summary>
    public static class ServiceRegistration  // Servis kayıtlarını yöneten yardımcı sınıf
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));  // MediatR servislerini ekle

            services.AddAutoMapper(typeof(MappingProfile));  // AutoMapper profilini ekle
            services.AddScoped<IJwtService,JwtService>();  // JWT servis kaydı
            services.AddScoped<AdminOnlyFilter>();  // Admin filtre kaydı
            services.AddHttpContextAccessor();  // HTTP context erişimi

            return services;  // Servis koleksiyonunu döndür
        }
    }
}
