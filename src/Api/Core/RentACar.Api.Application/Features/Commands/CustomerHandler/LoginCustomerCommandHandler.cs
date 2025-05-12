using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Core.RentACar.Api.Application.Services;
using RentACar.Api.Domain.Models;
using RentACar.Common.Infrastructure.PasswordEncryptor;
using RentACar.Common.Models.CommandModels.AppUserCommand;
using RentACar.Common.Models.CommandModels.CustomerCommand;
using RentACar.Infrastructure.Persistance.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Commands.CustomerHandler
{
    public class LoginCustomerCommandHandler : LoginBaseUserCommandHandler<Customer, LoginCustomerCommand>
    {
        public LoginCustomerCommandHandler(IBaseRepository<Customer> baseUserRepository, IJwtService jwtService) : base(baseUserRepository, jwtService)
        {
        }
    }
}
