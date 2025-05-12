using MediatR;
using RentACar.Common.Models.ViewModels.RentQuery;

namespace RentACar.Api.Application.Features.Queries.GetRents
{
    public class GetByIdRentQuery: IRequest<GetRentQuery>
    {
        public Guid Id { get; set; }
    }
}