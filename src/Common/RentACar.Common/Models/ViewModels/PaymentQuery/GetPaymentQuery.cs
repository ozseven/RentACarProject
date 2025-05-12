using RentACar.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.ViewModels.PaymentQuery
{
    public class GetPaymentQuery
    {
        public Guid RentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public bool Status { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public virtual Rent Rent { get; set; }
    }
}
