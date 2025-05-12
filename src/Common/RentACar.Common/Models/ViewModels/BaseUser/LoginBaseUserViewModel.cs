using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.ViewModels.BaseUser
{
    public class LoginBaseUserViewModel  // Giriş yapan kullanıcıya dönen model
    {
        public string JwtToken { get; set; }  // JWT token bilgisi
    }
}
