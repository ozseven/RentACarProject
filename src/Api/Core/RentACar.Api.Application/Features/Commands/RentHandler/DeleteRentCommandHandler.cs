using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Common.Models.CommandModels.RentCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Commands.RentHandler
{
    public class DeleteRentCommandHandler : IRequestHandler<DeleteRentCommand, Guid>
    {
        private readonly IRentRepository _repository;

        public DeleteRentCommandHandler(IRentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(DeleteRentCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.Id);
            await _repository.SaveChangesAsync();
            return request.Id;
        }
    }
}
