using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Common.Models.CommandModels.ProductCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Commands.ProductHandler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Guid>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.Id);
            await _repository.SaveChangesAsync();
            return request.Id;
        }
    }
}
