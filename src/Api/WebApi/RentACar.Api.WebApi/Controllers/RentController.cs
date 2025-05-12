using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Api.Application.Features.Queries.GetRents;
using RentACar.Common.Models.CommandModels.RentCommand;

namespace RentACar.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : BaseController
    {
        private readonly IMediator _mediator;

        public RentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRentCommand createRentCommand)
        {
            var result = await _mediator.Send(createRentCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteRentCommand deleteRentCommand)
        {
            var result = await _mediator.Send(deleteRentCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateRentCommand updateRentCommand)
        {
            var result = await _mediator.Send(updateRentCommand);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("rent/{id:guid}")]
        public async Task<IActionResult> GetRentById([FromRoute] Guid id)
        {
            var query = new GetByIdRentQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("rents")]
        public async Task<IActionResult> GetRents()
        {
            var result = await _mediator.Send(new GetAllRentQuery { UserId = UserId.Value});
            return Ok(result);
        }

    }
}
