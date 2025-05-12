using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Domain.Models
{
    /// <summary>
    /// Sistemdeki tüm kullanıcı türleri (Müşteri, Uygulama Kullanıcısı) için ortak temel özellikleri içeren soyut sınıfı temsil eder.
    /// </summary>
    public abstract class BaseUser:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
    }
}
