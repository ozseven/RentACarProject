using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Core.RentACar.Api.Application.Services;
using RentACar.Api.Domain.Models;
using RentACar.Common.Infrastructure.Exceptions;
using RentACar.Common.Infrastructure.PasswordEncryptor;
using RentACar.Common.Models.CommandModels;
using RentACar.Common.Models.ViewModels.BaseUser;
using RentACar.Infrastructure.Persistance.Services;

namespace RentACar.Api.Application.Features.Commands
{
    /// <summary>
    /// Temel kullanıcı girişi için komut işleyici sınıfı.
    /// Kullanıcı kimlik doğrulama ve JWT token üretimi işlemlerini yönetir.
    /// </summary>
    public abstract class LoginBaseUserCommandHandler<TEntity,LoginCommand>
        : IRequestHandler<LoginCommand, LoginBaseUserViewModel>  // Temel kullanıcı girişi işleyicisi
        where TEntity : BaseUser
        where LoginCommand : LoginBaseUserCommand<TEntity>
    {
        private readonly IBaseRepository<TEntity> _baseUserRepository;
        private readonly IJwtService _jwtService;

        /// <summary>
        /// Yeni bir <see cref="LoginBaseUserCommandHandler{TEntity, LoginCommand}"/> sınıfı örneği oluşturur.
        /// </summary>
        /// <param name="baseUserRepository">Kullanıcı verilerine erişim için repository.</param>
        /// <param name="jwtService">JWT token üretimi için servis.</param>
        public LoginBaseUserCommandHandler(IBaseRepository<TEntity> baseUserRepository,IJwtService jwtService)
        {
            _baseUserRepository = baseUserRepository;
            _jwtService = jwtService;
        }

        /// <summary>
        /// Giriş komutunu işler ve JWT token üretir.
        /// </summary>
        /// <param name="request">Giriş isteği.</param>
        /// <param name="cancellationToken">İptal belirteci.</param>
        /// <returns>Giriş başarılıysa, JWT token içeren bir <see cref="LoginBaseUserViewModel"/> döndürür.</returns>
        public async Task<LoginBaseUserViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _baseUserRepository.GetSingleAsync(u => u.Email == request.Email);  // Kullanıcıyı email ile bul
            if (user == null)
            {
                throw new DatabaseExistingValueException("Kullanıcı bulunamadı.");  // Kullanıcı yoksa hata
            }

            if (user.Password != PasswordEncryptor.Encrypt(request.Password))  // Şifre kontrolü
            {
                throw new DatabaseExistingValueException("Geçersiz şifre.");
            }
            LoginBaseUserViewModel viewModel = new LoginBaseUserViewModel() {
                JwtToken= _jwtService.GenerateToken(user)  // JWT token oluştur
            };
            return viewModel;  // Token ile birlikte sonucu döndür
        }
    }
}
