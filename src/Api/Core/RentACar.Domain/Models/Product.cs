using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Domain.Models
{
    /// <summary>
    /// Kiralanabilir bir ürünü (araç vb.) temsil eder.
    /// </summary>
    public class Product: BaseEntity
    {
        public Guid RentOfficeId { get; set; }
        public IEnumerable<Guid>? RentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; } 
        public string Category { get; set; } 
        public bool IsAvailable { get; set; } 
        public virtual ICollection<Rent> Rents { get; set; }
        public virtual RentOffice RentOffice { get; set; }
    }
}
