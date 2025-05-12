using AutoMapper;
using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Domain.Models;
using RentACar.Common.Models.CommandModels.RentOfficeCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Commands.RentHandler
{
    public class CreateRentOfficeCommandHandler : IRequestHandler<CreateRentOfficeCommand, Guid>
    {
        private readonly IRentOfficeRepository _repository;
        private readonly IMapper _mapper;
        public CreateRentOfficeCommandHandler(IRentOfficeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateRentOfficeCommand request, CancellationToken cancellationToken)
        {
            RentOffice rentOffice = _mapper.Map<RentOffice>(request);
            _repository.Update(rentOffice);
            await _repository.SaveChangesAsync();
            return rentOffice.Id;
        }
    }
}
