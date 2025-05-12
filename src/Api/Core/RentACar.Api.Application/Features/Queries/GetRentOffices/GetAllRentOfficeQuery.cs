using MediatR;
using RentACar.Common.Models.ViewModels.RentOfficeQuery;

namespace RentACar.Api.Application.Features.Queries.GetRentOffices
{
    public class GetAllRentOfficeQuery:IRequest<IEnumerable<GetRentOfficeQuery>>
    {
    }
}