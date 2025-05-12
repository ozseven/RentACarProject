using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Domain.Models
{
    /// <summary>
    /// Sisteme kayıtlı müşteriyi temsil eder.
    /// </summary>
    public class Customer : BaseUser
    {
        public DateOnly DrivingLicanceDateOfIssue { get; set; }
        public DrivingLicanceClass DrivingLicanceClass { get; set; }
        public DateTime BirthDate { get; set; }  
        public virtual IEnumerable<Rent> Rents { get; set; }


    }
    /// <summary>
    /// Müşterinin sahip olduğu ehliyet sınıfını belirtir.
    /// </summary>
    public enum DrivingLicanceClass
    {
        A1,
        A2,
        A,
        B1,
        B,
        BE,
        C1,
        C1E,
        C,
        CE,
        D1,
        D1E,
        D,
        DE,
        F,
        G,
        M
    }
}
