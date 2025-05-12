using MediatR;
using RentACar.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.ViewModels.AppUserQuery
{
    public class GetAppUserQuery:IRequest<Guid>
    {
        public Guid RentOfficeId { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
