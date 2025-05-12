using AutoMapper;
using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Common.Models.ViewModels.PaymentQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Queries.GetPayments
{
    public class GetByIdPaymentQueryHandler : IRequestHandler<GetByIdPaymentQuery,GetPaymentQuery>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public GetByIdPaymentQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<GetPaymentQuery> Handle(GetByIdPaymentQuery request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetByIdAsync(request.Id);
            if (payment == null)
            {
                throw new KeyNotFoundException($"Payment with ID {request.Id} not found.");
            }
            return _mapper.Map<GetPaymentQuery>(payment);
        }
    }
}
