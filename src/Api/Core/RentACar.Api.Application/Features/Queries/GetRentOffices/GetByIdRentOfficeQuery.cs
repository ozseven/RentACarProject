using MediatR;
using RentACar.Common.Models.ViewModels.RentOfficeQuery;

namespace RentACar.Api.Application.Features.Queries.GetRentOffices
{
    public class GetByIdRentOfficeQuery: IRequest<GetRentOfficeQuery>
    {
        public Guid Id { get; set; }
    }
}