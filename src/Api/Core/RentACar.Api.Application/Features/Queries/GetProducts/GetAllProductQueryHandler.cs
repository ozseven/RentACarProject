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
    public class GetAllProductQueryHandler:IRequestHandler<GetAllProductQuery, IEnumerable<GetProductQuery>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetProductQuery>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetAll();
            var productList = _mapper.Map<IEnumerable<GetProductQuery>>(products);
            return productList;
        }
    }

}
