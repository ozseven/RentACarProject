using AutoMapper;
using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Application.Utilities;
using RentACar.Api.Domain.Models;
using RentACar.Common.Infrastructure.PasswordEncryptor;
using RentACar.Common.Models.CommandModels.CustomerCommand.RentACar.Common.Models.CommandModels.AppUserCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Commands.CustomerHandler
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await ExistsDatabaseQuery<Customer>.IsExistingAsync(_repository, e => e.Email == request.Email);
            request.Password = PasswordEncryptor.Encrypt(request.Password);
            Customer dbEntity = _mapper.Map<Customer>(request);
            _repository.Update(dbEntity); // save changes async çalışmıyor!!!
            await _repository.SaveChangesAsync();
            return dbEntity.Id;
        }
    }
}
