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
    public class RentRepository : BaseRepository<Rent>, IRentRepository
    {
        public RentRepository(RentACarContext context) : base(context)
        {
        }
    }
}
