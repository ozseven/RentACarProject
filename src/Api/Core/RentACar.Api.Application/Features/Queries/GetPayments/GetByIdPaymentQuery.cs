using MediatR;
using RentACar.Common.Models.ViewModels.PaymentQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Queries.GetPayments
{
    public class GetByIdPaymentQuery:IRequest<GetPaymentQuery>
    {
        public Guid Id { get; set; }
    }
}
