using AutoMapper;
using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Common.Models.ViewModels.AppUserQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Queries.GetAppUsers
{
    public class GetByIdAppUserQueryHandler:IRequestHandler<GetByIdAppUserQuery, GetAppUserQuery>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public GetByIdAppUserQueryHandler(IAppUserRepository appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }

        public async Task<GetAppUserQuery> Handle(GetByIdAppUserQuery request, CancellationToken cancellationToken)
        {
            var appUser =await _appUserRepository.GetByIdAsync(request.Id);
            var appUserView = _mapper.Map<GetAppUserQuery>(appUser);
            return appUserView;
        }
    }
}
