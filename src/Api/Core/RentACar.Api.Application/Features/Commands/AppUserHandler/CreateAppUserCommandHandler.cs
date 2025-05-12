using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Application.Utilities;
using RentACar.Api.Domain.Models;
using AutoMapper;
using RentACar.Common.Infrastructure.PasswordEncryptor;
using RentACar.Common.Models.CommandModels.AppUserCommand;

namespace RentACar.Api.Application.Features.Commands.AppUserHandler
{
    /// <summary>
    /// Yeni bir uygulama kullanıcısı oluşturma işlemini yöneten sınıf.
    /// </summary>
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, Guid>  // Yeni uygulama kullanıcısı oluşturma işleyicisi
    {
        private readonly IAppUserRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// CreateAppUserCommandHandler sınıfını başlatır.
        /// </summary>
        /// <param name="repository">Kullanıcı veritabanı işlemleri için repository.</param>
        /// <param name="mapper">Veri dönüşümleri için mapper.</param>
        public CreateAppUserCommandHandler(IAppUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Yeni bir kullanıcı oluşturur.
        /// </summary>
        /// <param name="request">Kullanıcı bilgilerini içeren komut.</param>
        /// <param name="cancellationToken">İptal tokeni.</param>
        /// <returns>Oluşturulan kullanıcının ID'si.</returns>
        public async Task<Guid> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await ExistsDatabaseQuery<AppUser>.IsExistingAsync(_repository, e => e.Email == request.Email);  // Email kontrolü
            request.Password = PasswordEncryptor.Encrypt(request.Password);  // Şifreyi şifrele
            AppUser dbEntity = _mapper.Map<AppUser>(request);  // Request'i AppUser'a dönüştür
            _repository.Update(dbEntity);
            await _repository.SaveChangesAsync();  // Veritabanına kaydet
            return dbEntity.Id;  // Oluşturulan kullanıcının ID'sini döndür
        }
    }
}
