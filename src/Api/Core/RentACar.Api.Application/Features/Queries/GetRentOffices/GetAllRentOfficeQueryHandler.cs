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
    public class GetAllRentOfficeQueryHandler: IRequestHandler<GetAllRentOfficeQuery, IEnumerable<GetRentOfficeQuery>>
    {
        private readonly IRentOfficeRepository _rentOfficeRepository;
        private readonly IMapper _mapper;
        public GetAllRentOfficeQueryHandler(IRentOfficeRepository rentOfficeRepository, IMapper mapper)
        {
            _rentOfficeRepository = rentOfficeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetRentOfficeQuery>> Handle(GetAllRentOfficeQuery request, CancellationToken cancellationToken)
        {
            var rentOffices = _rentOfficeRepository.GetAll();
            var rentOfficeList = _mapper.Map<IEnumerable<GetRentOfficeQuery>>(rentOffices);
            return rentOfficeList;
        }
    }
}
