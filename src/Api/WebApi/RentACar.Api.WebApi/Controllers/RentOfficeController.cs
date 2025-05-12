using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Api.Application.Authorization;
using RentACar.Api.Application.Features.Queries.GetRentOffices;
using RentACar.Common.Models.CommandModels.RentOfficeCommand;

namespace RentACar.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentOfficeController : BaseController
    {
        private readonly IMediator _mediator;

        public RentOfficeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Create RentOffice
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRentOfficeCommand createRentOfficeCommand)
        {
            var result = await _mediator.Send(createRentOfficeCommand);
            return Ok(result);
        }

        // Delete RentOffice (Only Authorized)
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteRentOfficeCommand deleteRentOfficeCommand)
        {
            var result = await _mediator.Send(deleteRentOfficeCommand);
            return Ok(result);
        }

        // Update RentOffice (Only Authorized)
        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateRentOfficeCommand updateRentOfficeCommand)
        {
            var result = await _mediator.Send(updateRentOfficeCommand);
            return Ok(result);
        }
        [HttpGet("rentoffice/{id:guid}")]
        public async Task<IActionResult> GetRentOfficeById([FromRoute] Guid id)
        {
            var query = new GetByIdRentOfficeQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("rentoffices")]
        public async Task<IActionResult> GetRentOffices([FromQuery] GetAllRentOfficeQuery getRentOfficesQuery)
        {
            var result = await _mediator.Send(getRentOfficesQuery);
            return Ok(result);
        }
    }
}
