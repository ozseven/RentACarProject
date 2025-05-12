using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.CommandModels.RentCommand
{
    public class UpdateRentCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid RentOfficeId { get; set; }
        public Guid CustomerId { get; set; }
        public IEnumerable<Guid> ProductIds { get; set; }
        public IEnumerable<Guid>? PaymentIds { get; set; }
        public Guid AppUserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string RentType { get; set; }
    }
}
