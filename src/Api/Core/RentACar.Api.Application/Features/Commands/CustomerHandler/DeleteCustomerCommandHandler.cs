using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Common.Models.CommandModels.CustomerCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Commands.CustomerHandler
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _repository;

        public DeleteCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.Id);
            await _repository.SaveChangesAsync();
            return request.Id;
        }
    }
}
