using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.CommandModels.AppUserCommand
{
    /// <summary>
    /// Uygulama kullanıcısı silme işlemi için komut sınıfı.
    /// Belirtilen ID'ye sahip kullanıcının sistemden silinmesi için kullanılır.
    /// </summary>
    public class DeleteAppUserCommand: IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
