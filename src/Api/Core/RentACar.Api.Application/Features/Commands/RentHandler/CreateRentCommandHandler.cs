using AutoMapper;
using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Domain.Models;
using RentACar.Common.Models.CommandModels.RentCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Commands.RentHandler
{
    public class CreateRentCommandHandler : IRequestHandler<CreateRentCommand, Guid>
    {
        private readonly IRentRepository _repository;
        private readonly IMapper _mapper;

        public CreateRentCommandHandler(IRentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateRentCommand request, CancellationToken cancellationToken)
        {
            Rent rent = _mapper.Map<Rent>(request);
            _repository.Update(rent);
            await _repository.SaveChangesAsync();
            return rent.Id;
        }
    }
}
