using AutoMapper;
using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Common.Models.ViewModels.ProductQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Queries.GetProducts
{
    public class GetByIdProductQueryHandler:IRequestHandler<GetByIdProductQuery, GetProductQuery>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetProductQuery> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }
            return _mapper.Map<GetProductQuery>(product);
        }
    }
}
