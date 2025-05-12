using AutoMapper;
using Microsoft.Extensions.Configuration;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Core.RentACar.Api.Application.Services;
using RentACar.Api.Domain.Models;
using RentACar.Common.Models.CommandModels.AppUserCommand;
using RentACar.Infrastructure.Persistance.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Commands.AppUserHandler
{

    public class LoginAppUserCommandHandler : LoginBaseUserCommandHandler<AppUser, LoginAppUserCommand>
    {
        public LoginAppUserCommandHandler(IBaseRepository<AppUser> baseUserRepository, IJwtService jwtService) : base(baseUserRepository, jwtService)
        {
        }
    }
}
