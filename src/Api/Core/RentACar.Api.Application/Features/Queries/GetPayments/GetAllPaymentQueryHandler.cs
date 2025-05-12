using AutoMapper;
using MediatR;
using Newtonsoft.Json.Linq;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Common.Models.ViewModels.CustomerQuery;
using RentACar.Common.Models.ViewModels.PaymentQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Queries.GetPayments
{
    public class GetAllPaymentQueryHandler : IRequestHandler<GetAllPaymentQuery, IEnumerable<GetPaymentQuery>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public GetAllPaymentQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetPaymentQuery>> Handle(GetAllPaymentQuery request, CancellationToken cancellationToken)
        {
            var payments = _paymentRepository.GetAll().Where(p=>p.Rent.CustomerId == request.UserId);
            var paymentView=  _mapper.Map<IEnumerable<GetPaymentQuery>>(payments);
            return paymentView;
        }
    }
}
