using RentACar.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.CommandModels.AppUserCommand
{
    /// <summary>
    /// Uygulama kullanıcısı girişi için komut sınıfı.
    /// LoginBaseUserCommand sınıfından türetilmiş olup, AppUser tipi için özelleştirilmiştir.
    /// </summary>
    public class LoginAppUserCommand:LoginBaseUserCommand<AppUser>
    {
    }
}
