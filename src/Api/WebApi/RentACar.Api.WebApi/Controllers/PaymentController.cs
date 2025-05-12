using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Api.Application.Features.Queries.GetPayments;
using RentACar.Common.Models.CommandModels.PaymentCommand;

namespace RentACar.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseController
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreatePaymentCommand createPaymentCommand)
        {
            var result = await _mediator.Send(createPaymentCommand);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Guid paymentId)
        {
            var claimsList = HttpContext.User.Claims.ToList();
            var userId = claimsList[0].Value;
            DeletePaymentCommand deletePaymentCommand = new DeletePaymentCommand
            {
                Id = paymentId,
                UserId = Guid.Parse(userId)

            };
            var result = await _mediator.Send(deletePaymentCommand);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("getallpayments")]
        public async Task<IActionResult> GetPayments()
        {
            var result =await _mediator.Send(new GetAllPaymentQuery { UserId = UserId.Value });
            return Ok(result);
        }
        [Authorize]
        [HttpGet("payment/{Id:guid}")]
        public async Task<IActionResult> GetByIdPayment([FromRoute] Guid Id)
        {
            var query = new GetByIdPaymentQuery { Id = Id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }


    }
}
