using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Domain.Models
{
    /// <summary>
    /// Kiralama ofisini temsil eder.
    /// </summary>
    public class RentOffice:BaseEntity
    {
        public IEnumerable<Guid>? ProductsId { get; set; }
        
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } 
        public string City { get; set; } 
        public string Country { get; set; }
        public virtual IEnumerable<Product>? Products { get; set; }
        public virtual IEnumerable<AppUser>? AppUsers { get; set; }
        public virtual IEnumerable<Rent>? Rents { get; set; }
    }
}
