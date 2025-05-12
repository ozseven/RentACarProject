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
    public class GetAllRentQueryHandler: IRequestHandler<GetAllRentQuery, IEnumerable<GetRentQuery>>
    {
        private readonly IRentRepository _rentRepository;
        private readonly IMapper _mapper;
        public GetAllRentQueryHandler(IRentRepository rentRepository, IMapper mapper)
        {
            _rentRepository = rentRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetRentQuery>> Handle(GetAllRentQuery request, CancellationToken cancellationToken)
        {
            var rents = _rentRepository.GetAll().Where(r=>r.CustomerId==request.UserId);
            var rentList = _mapper.Map<IEnumerable<GetRentQuery>>(rents);
            return rentList;
        }
    }

}
