using MediatR;
using RentACar.Api.Domain.Models;
using RentACar.Common.Models.ViewModels.BaseUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.CommandModels
{
    /// <summary>
    /// Temel kullanıcı girişi için soyut komut sınıfı.
    /// Bu sınıf, farklı kullanıcı tipleri için giriş işlemlerini yönetir.
    /// </summary>
    /// <typeparam name="TEntity">BaseUser'dan türetilmiş kullanıcı tipi</typeparam>
    public abstract class LoginBaseUserCommand<TEntity>:IRequest<LoginBaseUserViewModel> where TEntity : BaseUser
    {
        public string Email { get; set; }
        public String Password { get; set; }
    }
}
