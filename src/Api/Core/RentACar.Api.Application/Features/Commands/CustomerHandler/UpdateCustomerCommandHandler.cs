using AutoMapper;
using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Application.Utilities;
using RentACar.Api.Domain.Models;
using RentACar.Common.Infrastructure.PasswordEncryptor;
using RentACar.Common.Models.CommandModels.CustomerCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Commands.CustomerHandler
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer dbEntity = await _repository.GetByIdAsync(request.Id);
            if (dbEntity != null)
            {
                if (dbEntity.Email != request.Email)
                    await ExistsDatabaseQuery<Customer>.IsExistingAsync(_repository, e => e.Email == request.Email);
            }
            request.Password = PasswordEncryptor.Encrypt(request.Password);
            _mapper.Map(request, dbEntity);
            _repository.Update(dbEntity); // save changes async çalışmıyor!!!
            await _repository.SaveChangesAsync();

            return request.Id;
        }
    }
}
