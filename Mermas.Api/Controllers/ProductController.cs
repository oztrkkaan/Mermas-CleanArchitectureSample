using MediatR;
using Mermas.Api.Common;
using Mermas.Application.Products.Commands;
using Mermas.Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mermas.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : MediatrControllerBase
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<CreateProductResponse> Create([FromBody] CreateProductCommand request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);

        [HttpGet]
        public async Task<List<GetProductsByFilterResponse>> GetByFilter([FromQuery] GetProductsByFilterQuery request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);

        [HttpDelete]
        public async Task<DeleteProductResponse> Delete([FromBody] DeleteProductCommand request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);

        [HttpPut]
        public async Task<UpdateProductResponse> UpdateInfo([FromBody] UpdateProductInfoCommand request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);

        [HttpPut]
        public async Task<UpdateProductStockQuantityResponse> UpdateStockQuantity([FromBody] UpdateProductStockQuantityCommand request, CancellationToken cancellationToken)
        => await _mediator.Send(request, cancellationToken);
    }
}
