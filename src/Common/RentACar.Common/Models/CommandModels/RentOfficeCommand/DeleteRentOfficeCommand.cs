using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.CommandModels.RentOfficeCommand
{
    public class DeleteRentOfficeCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
