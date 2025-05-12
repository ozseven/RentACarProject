using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Api.Application.Authorization;
using RentACar.Api.Application.Features.Queries.GetProducts;
using RentACar.Api.Domain.Models;
using RentACar.Common.Models.CommandModels.ProductCommand;

namespace RentACar.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Policy = "AppUserOnly")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var result = await _mediator.Send(createProductCommand);
            return Ok(result);
        }

        [Authorize(Policy = "AppUserOnly")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand deleteProductCommand)
        {
            var result = await _mediator.Send(deleteProductCommand);
            return Ok(result);
        }

        [Authorize(Policy = "AppUserOnly")]
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            var result = await _mediator.Send(updateProductCommand);
            return Ok(result);
        }
        [HttpGet("getallproducts")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _mediator.Send(new GetAllProductQuery());
            return Ok(result);
        }
        [HttpGet("{Id:Guid}")]
        public async Task<IActionResult> Get([FromBody]Guid Id)
        {
            var result = await _mediator.Send(new GetByIdProductQuery { Id = Id });
            return Ok(result);
        }
    }
}
