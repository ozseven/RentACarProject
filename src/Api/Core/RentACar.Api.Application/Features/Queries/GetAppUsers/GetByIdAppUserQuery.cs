using MediatR;
using RentACar.Common.Models.ViewModels.AppUserQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Queries.GetAppUsers
{
    public class GetByIdAppUserQuery:IRequest<GetAppUserQuery>
    {
        public Guid Id { get; set; }
    }
}
