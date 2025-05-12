using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.CommandModels.CustomerCommand
{
    public class DeleteCustomerCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
