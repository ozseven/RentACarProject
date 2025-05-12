using RentACar.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.ViewModels.CustomerQuery
{
    public class GetCustomerQuery
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateOnly DrivingLicanceDateOfIssue { get; set; }
        public DrivingLicanceClass DrivingLicanceClass { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual IEnumerable<Rent> Rents { get; set; }
    }
}
