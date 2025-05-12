using AutoMapper;
using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Common.Models.CommandModels.RentOfficeCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Commands.RentHandler
{
    public class DeleteRentOfficeCommandHandler:IRequestHandler<DeleteRentOfficeCommand, Guid>
    {
        private readonly IRentOfficeRepository _repository;
        private readonly IMapper _mapper;

        public DeleteRentOfficeCommandHandler(IRentOfficeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(DeleteRentOfficeCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.Id);
            await _repository.SaveChangesAsync();
            return request.Id;
        }
    }
}
