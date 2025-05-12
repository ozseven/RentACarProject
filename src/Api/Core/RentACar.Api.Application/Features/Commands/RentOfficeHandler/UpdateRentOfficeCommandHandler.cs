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
    public class UpdateRentOfficeCommandHandler:IRequestHandler<UpdateRentOfficeCommand, Guid>
    {
        private readonly IRentOfficeRepository _repository;
        private readonly IMapper _mapper;
        public UpdateRentOfficeCommandHandler(IRentOfficeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(UpdateRentOfficeCommand request, CancellationToken cancellationToken)
        {
            var dbEntity = await _repository.GetByIdAsync(request.Id);
            _mapper.Map(request,dbEntity);
            _repository.Update(dbEntity);
            await _repository.SaveChangesAsync();
            return dbEntity.Id;
        }
    }
}
