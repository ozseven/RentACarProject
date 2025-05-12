using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Common.Models.CommandModels;
using RentACar.Api.Domain.Models;

namespace RentACar.Common.Models.CommandModels.CustomerCommand
{
    /// <summary>
    /// Müşteri girişi için komut sınıfı.
    /// LoginBaseUserCommand sınıfından türetilmiş olup, Customer tipi için özelleştirilmiştir.
    /// Müşterilerin sisteme giriş yapması için kullanılır.
    /// </summary>
    public class LoginCustomerCommand : LoginBaseUserCommand<Customer>
    {
    }
}
