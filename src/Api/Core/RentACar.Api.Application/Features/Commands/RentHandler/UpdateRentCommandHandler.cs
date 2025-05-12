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
    public class UpdateRentCommandHandler : IRequestHandler<UpdateRentCommand, Guid>
    {
        private readonly IRentRepository _repository;
        private readonly IMapper _mapper;

        public UpdateRentCommandHandler(IRentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateRentCommand request, CancellationToken cancellationToken)
        {
            Rent dbEntity = await _repository.GetByIdAsync(request.Id);
            if (dbEntity != null)
            {
                _mapper.Map(request, dbEntity);
                _repository.Update(dbEntity);
                await _repository.SaveChangesAsync();
            }
            return request.Id;
        }
    }
}
