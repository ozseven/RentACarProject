using MediatR;
using RentACar.Common.Models.ViewModels.CustomerQuery;

namespace RentACar.Api.Application.Features.Queries.GetCustomers
{
    public class GetAllCustomerQuery:IRequest<IEnumerable<GetCustomerQuery>>
    {
    }
}