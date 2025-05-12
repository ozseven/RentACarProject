using AutoMapper;
using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Domain.Models;
using RentACar.Common.Models.CommandModels.PaymentCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Commands.PaymentHandler
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Guid>
    {
        private readonly IPaymentRepository _repository;
        private readonly IMapper _mapper;

        public CreatePaymentCommandHandler(IPaymentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            Payment payment = _mapper.Map<Payment>(request);
            _repository.Update(payment); 
            await _repository.SaveChangesAsync();
            return payment.Id;
        }
    }
}
