using MediatR;
using RentACar.Common.Models.ViewModels.CustomerQuery;
using RentACar.Common.Models.ViewModels.PaymentQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Queries.GetPayments
{
    public class GetAllPaymentQuery:IRequest<IEnumerable<GetPaymentQuery>>
    {
        public Guid UserId { get; set; }
    }
}
