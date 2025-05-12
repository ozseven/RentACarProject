using MediatR;
using RentACar.Common.Infrastructure.PasswordEncryptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.CommandModels.CustomerCommand
{
    /// <summary>
    /// Yeni müşteri oluşturma işlemi için komut sınıfı.
    /// Müşteri kaydı için gerekli tüm bilgileri içerir.
    /// </summary>
    namespace RentACar.Common.Models.CommandModels.AppUserCommand
    {
        public class CreateCustomerCommand : IRequest<Guid>
        {
            /// <summary>
            /// Müşterinin adı
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Müşterinin soyadı
            /// </summary>
            public string Surname { get; set; }

            /// <summary>
            /// Müşterinin şifresi
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// Müşterinin e-posta adresi
            /// </summary>
            public string Email { get; set; }

            /// <summary>
            /// Müşterinin telefon numarası
            /// </summary>
            public string PhoneNumber { get; set; }

            /// <summary>
            /// Müşterinin adresi
            /// </summary>
            public string Address { get; set; }

            /// <summary>
            /// Müşterinin kimlik numarası
            /// </summary>
            public string IdentityNumber { get; set; }
        }
    }
}
