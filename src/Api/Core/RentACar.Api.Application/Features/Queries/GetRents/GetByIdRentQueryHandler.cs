using AutoMapper;
using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Common.Models.ViewModels.RentQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Queries.GetRents
{
    public class GetByIdRentQueryHandler: IRequestHandler<GetByIdRentQuery, GetRentQuery>
    {
        private readonly IRentRepository _rentRepository;
        private readonly IMapper _mapper;
        public GetByIdRentQueryHandler(IRentRepository rentRepository, IMapper mapper)
        {
            _rentRepository = rentRepository;
            _mapper = mapper;
        }
        public async Task<GetRentQuery> Handle(GetByIdRentQuery request, CancellationToken cancellationToken)
        {
            var rent = _rentRepository.GetByIdAsync(request.Id);
            if (rent == null)
            {
                throw new KeyNotFoundException($"Rent with ID {request.Id} not found.");
            }
            return _mapper.Map<GetRentQuery>(rent);
        }
    }
}
