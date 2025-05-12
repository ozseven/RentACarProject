using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.CommandModels.CustomerCommand
{
    /// <summary>
    /// Müşteri bilgilerini güncelleme işlemi için komut sınıfı.
    /// Mevcut müşteri kaydının güncellenmesi için gerekli verileri içerir.
    /// </summary>
    public class UpdateCustomerCommand : IRequest<Guid>
    {
        /// <summary>
        /// Güncellenecek müşterinin benzersiz tanımlayıcısı
        /// </summary>
        public Guid Id { get; set; }

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
