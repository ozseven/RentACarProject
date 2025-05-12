using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.CommandModels.ProductCommand
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid RentOfficeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
    }
}
