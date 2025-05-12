using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Common.Models.CommandModels.CustomerCommand.RentACar.Common.Models.CommandModels.AppUserCommand;
using RentACar.Common.Models.CommandModels.CustomerCommand;
using RentACar.Common.Models.CommandModels;
using RentACar.Api.Application.Authorization;
using RentACar.Api.Application.Features.Queries.GetAppUsers;
using RentACar.Api.Application.Features.Queries.GetCustomers;

namespace RentACar.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            var result = await _mediator.Send(createCustomerCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommand deleteCustomerCommand)
        {
            var result = await _mediator.Send(deleteCustomerCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            var result = await _mediator.Send(updateCustomerCommand);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCustomerCommand loginCustomerCommand)
        {
            var result = await _mediator.Send(loginCustomerCommand);
            return Ok(result);
        }
        [HttpGet("account")]
        [Authorize]
        public async Task<IActionResult> GetById()
        {
            if (null == UserId)
                return BadRequest("UserId is null");
            var result = await _mediator.Send(new GetByIdCustomerQuery { Id = UserId.Value });
            return Ok(result);
        }
    }
}
