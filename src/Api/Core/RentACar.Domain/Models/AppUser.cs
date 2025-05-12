using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Domain.Models
{
    /// <summary>
    /// Uygulama kullanıcısını (çalışan veya yönetici) temsil eder.
    /// </summary>
    public class AppUser:BaseUser
    {
        public Guid RentOfficeId { get; set; }
        public Status Status { get; set; }
        public virtual RentOffice RentOffice { get; set; }
        public virtual IEnumerable<Rent> Rents { get; set; }
    }
    /// <summary>
    /// Uygulama kullanıcısının durumunu belirtir (Yönetici veya Çalışan).
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Yönetici yetkilerine sahip kullanıcı.
        /// </summary>
        Admin,
        /// <summary>
        /// Standart çalışan yetkilerine sahip kullanıcı.
        /// </summary>
        Employee
    }
}
