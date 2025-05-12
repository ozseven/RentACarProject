using AutoMapper;
using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Application.Utilities;
using RentACar.Api.Domain.Models;
using RentACar.Common.Infrastructure.PasswordEncryptor;
using RentACar.Common.Models.CommandModels.AppUserCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Commands.AppUserHandler
{
    public class UpdateAppUserCommondHandler: IRequestHandler<UpdateAppUserCommand, Guid>  // Uygulama kullanıcısı güncelleme işleyicisi
    {
        private readonly IAppUserRepository _repository;
        private readonly IMapper _mapper;

        public UpdateAppUserCommondHandler(IAppUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser dbEntity = await _repository.GetByIdAsync(request.Id);  // Kullanıcıyı bul
            if (dbEntity != null) {
                if (dbEntity.Email != request.Email)
                    await ExistsDatabaseQuery<AppUser>.IsExistingAsync(_repository, e => e.Email == request.Email);  // Email kontrolü
            }
            request.Password = PasswordEncryptor.Encrypt(request.Password);  // Şifreyi şifrele
            _mapper.Map(request, dbEntity);  // Request'i mevcut kullanıcıya uygula
            _repository.Update(dbEntity);  // Güncelle
            await _repository.SaveChangesAsync();  // Değişiklikleri kaydet

            return request.Id;  // Güncellenen kullanıcının ID'si
        }
    }
}

