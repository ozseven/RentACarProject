using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Infrastructure.Persistance.Context;
using RentACar.Infrastructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Persistance.Registration
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<RentACarContext>(conf =>
            {
                var connStr = configuration["ConnectionStrings:PostgreSQL"].ToString();
                conf.UseNpgsql(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped<IRentOfficeRepository, RentOfficeRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}
