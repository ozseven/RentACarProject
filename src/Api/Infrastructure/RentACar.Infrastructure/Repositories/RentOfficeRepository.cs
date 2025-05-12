using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Api.Domain.Models;
using RentACar.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Infrastructure.Persistance.Repositories
{
    public class RentOfficeRepository : BaseRepository<RentOffice>, IRentOfficeRepository
    {
        public RentOfficeRepository(RentACarContext context) : base(context)
        {
        }
    }
}
