using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Api.Application.Authorization;
using RentACar.Api.Application.Features.Queries.GetAppUsers;
using RentACar.Api.Application.Features.Queries.GetCustomers;
using RentACar.Api.Domain.Models;
using RentACar.Common.Models.CommandModels.AppUserCommand;

namespace RentACar.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : BaseController
    {
        private readonly IMediator _mediator;

        public AppUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppUserCommand createAppUserCommand)
        {
            var result = await _mediator.Send(createAppUserCommand);
            return Ok(result);
        }
        [Authorize]
        [OwnershipBaseUserAuthorization<AppUser>]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteAppUserCommand deleteAppUserCommand)
        {
            var result = await _mediator.Send(deleteAppUserCommand);
            return Ok(result);
        }

        [Authorize]
        [OwnershipBaseUserAuthorization<AppUser>]
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateAppUserCommand updateAppUserCommand)
        {
            var result = await _mediator.Send(updateAppUserCommand);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginAppUserCommand loginAppUserCommand)
        {
            var result = await _mediator.Send(loginAppUserCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllAppUserQuery());
            return Ok(result);
        }
        [HttpGet("account")]
        [Authorize]
        public async Task<IActionResult> GetById()
        {
            if (null == UserId)
                return BadRequest("UserId is null");
            var result = await _mediator.Send(new GetByIdAppUserQuery { Id = UserId.Value });
            return Ok(result);
        }
        [HttpGet("getall")]
        [Authorize]
        [ServiceFilter(typeof(AdminOnlyFilter))]
        public async Task<IActionResult> GetAllAppUser()
        {
            var result = await _mediator.Send(new GetAllAppUserQuery());
            return Ok(result);
        }
        [HttpGet("getall/customer")]
        [Authorize]
        [ServiceFilter(typeof(AdminOnlyFilter))]
        public async Task<IActionResult> GetAllCustomerUser()
        {
            var result = await _mediator.Send(new GetAllCustomerQuery());
            return Ok(result);
        }
    }
}
