using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Domain.Models
{
    /// <summary>
    /// Bir ürünün (veya ürünlerin) belirli bir müşteri tarafından kiralanması işlemini temsil eder.
    /// </summary>
    public class Rent:BaseEntity
    {
        public Guid RentOfficeId { get; set; }
        public Guid CustomerId { get; set; }
        public IEnumerable<Guid> ProductIds { get; set; }
        public IEnumerable<Guid>? PaymentIds { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual RentOffice RentOffice { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
        public virtual IEnumerable<Payment> Payments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string RentType { get; set; }
    }
}
