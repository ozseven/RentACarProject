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
    public class UpdateAppUserCommondHandler: IRequestHandler<UpdateAppUserCommand, Guid>
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
            AppUser dbEntity = await _repository.GetByIdAsync(request.Id);
            if (dbEntity != null) {
                if (dbEntity.Email != request.Email)
                    await ExistsDatabaseQuery<AppUser>.IsExistingAsync(_repository, e => e.Email == request.Email);
            }
            request.Password = PasswordEncryptor.Encrypt(request.Password);
            _mapper.Map(request, dbEntity);
            _repository.Update(dbEntity);//save changes async çalışmıyor!!!
            await _repository.SaveChangesAsync();

            return request.Id;
        }
    }
    
    }

