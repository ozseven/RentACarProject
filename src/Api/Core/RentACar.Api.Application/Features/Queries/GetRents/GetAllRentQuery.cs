using MediatR;
using RentACar.Common.Models.ViewModels.RentQuery;

namespace RentACar.Api.Application.Features.Queries.GetRents
{
    public class GetAllRentQuery: IRequest<IEnumerable<GetRentQuery>>
    {
        public Guid UserId { get; set; }
    }
}