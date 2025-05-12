using MediatR;
using RentACar.Common.Models.ViewModels.ProductQuery;

namespace RentACar.Api.Application.Features.Queries.GetProducts
{
    public class GetByIdProductQuery:IRequest<GetProductQuery>
    {
        public Guid Id { get; set; }
    }
}