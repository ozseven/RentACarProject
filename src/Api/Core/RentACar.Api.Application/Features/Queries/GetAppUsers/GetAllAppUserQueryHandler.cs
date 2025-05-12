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
    internal class GetAllAppUserQueryHandler:IRequestHandler<GetAllAppUserQuery, IEnumerable<GetAppUserQuery>>  // Tüm kullanıcıları listeleyen işleyici
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;
        public GetAllAppUserQueryHandler(IAppUserRepository appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAppUserQuery>> Handle(GetAllAppUserQuery request, CancellationToken cancellationToken)
        {
            var appUsers = _appUserRepository.GetAll();  // Tüm kullanıcıları getir
            var appUserList = _mapper.Map<IEnumerable<GetAppUserQuery>>(appUsers);  // Kullanıcıları ViewModel'e dönüştür
            return appUserList;  // Sonucu döndür
        }
    }
}
