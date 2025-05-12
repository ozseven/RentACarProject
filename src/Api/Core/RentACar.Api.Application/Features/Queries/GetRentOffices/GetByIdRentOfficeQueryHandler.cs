using AutoMapper;
using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Common.Models.ViewModels.RentOfficeQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Queries.GetRentOffices
{
    public class GetByIdRentOfficeQueryHandler: IRequestHandler<GetByIdRentOfficeQuery, GetRentOfficeQuery>
    {
        private readonly IRentOfficeRepository _rentOfficeRepository;
        private readonly IMapper _mapper;
        public GetByIdRentOfficeQueryHandler(IRentOfficeRepository rentOfficeRepository, IMapper mapper)
        {
            _rentOfficeRepository = rentOfficeRepository;
            _mapper = mapper;
        }
        public async Task<GetRentOfficeQuery> Handle(GetByIdRentOfficeQuery request, CancellationToken cancellationToken)
        {
            var rentOffice =await _rentOfficeRepository.GetByIdAsync(request.Id);
            if (rentOffice == null)
            {
                throw new KeyNotFoundException($"Rent office with ID {request.Id} not found.");
            }
            return _mapper.Map<GetRentOfficeQuery>(rentOffice);
        }
    }
}
