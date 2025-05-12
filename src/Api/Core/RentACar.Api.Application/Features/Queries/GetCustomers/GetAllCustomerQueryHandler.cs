using AutoMapper;
using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Common.Models.ViewModels.CustomerQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Queries.GetCustomers
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<GetCustomerQuery>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetAllCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCustomerQuery>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = _customerRepository.GetAll();
            return _mapper.Map<IEnumerable<GetCustomerQuery>>(customers);

        }
    }
}
