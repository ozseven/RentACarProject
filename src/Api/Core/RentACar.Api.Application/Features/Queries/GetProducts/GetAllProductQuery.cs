using MediatR;
using RentACar.Common.Models.ViewModels.ProductQuery;

namespace RentACar.Api.Application.Features.Queries.GetProducts
{
    public class GetAllProductQuery:IRequest<IEnumerable<GetProductQuery>>
    {
    }
}