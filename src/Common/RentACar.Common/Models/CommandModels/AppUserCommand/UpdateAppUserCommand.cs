using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.CommandModels.AppUserCommand
{
    /// <summary>
    /// Uygulama kullanıcısı güncelleme işlemi için komut sınıfı.
    /// Kullanıcı bilgilerinin güncellenmesi için gerekli verileri içerir.
    /// </summary>
    public class UpdateAppUserCommand : IRequest<Guid>
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public Guid RentOfficeId { get; set; }
    }
}

