using MediatR;
using RentACar.Api.Application.Authorization;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Domain.Models;
using RentACar.Common.Infrastructure.Exceptions;
using RentACar.Common.Models.CommandModels.PaymentCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Commands.PaymentHandler
{
    public class DeletePaymentCommandHandler:IRequestHandler<DeletePaymentCommand, Guid>
    {
        private readonly IPaymentRepository _repository;
        public DeletePaymentCommandHandler(IPaymentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var entityObj = await _repository.GetByIdAsync(request.Id);
            if (entityObj == null)
                throw new DatabaseNotFoundValueException("Payment not found");
            if (entityObj.Rent.CustomerId != request.UserId)
            {
                throw new UnauthorizedAccessException("You are not authorized to access this resource.");
            }
            await _repository.RemoveAsync(request.Id);
            await _repository.SaveChangesAsync();
            return request.Id;

        }
    }
}
