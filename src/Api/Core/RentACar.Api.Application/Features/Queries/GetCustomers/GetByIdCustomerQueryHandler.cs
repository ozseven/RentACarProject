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
    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, GetCustomerQuery>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetByIdCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<GetCustomerQuery> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GetCustomerQuery>(customer);
        }
    }
}
