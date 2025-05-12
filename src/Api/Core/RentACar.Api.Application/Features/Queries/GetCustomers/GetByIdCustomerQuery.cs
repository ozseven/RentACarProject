using MediatR;
using RentACar.Common.Models.ViewModels.CustomerQuery;

namespace RentACar.Api.Application.Features.Queries.GetCustomers
{
    public class GetByIdCustomerQuery:IRequest<GetCustomerQuery>
    {
        public Guid Id { get; set; }
    }
}