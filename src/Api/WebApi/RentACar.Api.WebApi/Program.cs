using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RentACar.Api.Application.Registration;
using RentACar.Infrastructure.Persistance.Registration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle
builder.Services.AddControllers();
builder.Services.AddOpenApi();  // OpenAPI dokümantasyonu

builder.Services.AddApplicationServices();  // Uygulama servislerini ekle
builder.Services.AddInfrastructureRegistration(builder.Configuration);  // Altyapı servislerini ekle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument();

// JWT kimlik doğrulama ekle
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AppUserOnly", policy =>
        policy.RequireClaim("typ", "AppUser"));  // Sadece AppUser tipine sahip kullanıcılar
});

var app = builder.Build();

// HTTP pipeline yapılandırması
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseAuthentication();  // Kimlik doğrulama middleware
app.UseAuthorization();  // Yetkilendirme middleware

app.MapControllers();  // Controller endpointlerini ekle

app.Run();
