using MediatR;
using Mermas.Api.Common;
using Mermas.Application.Merchant.Commands;
using Mermas.Application.Merchant.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mermas.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MerchantController : MediatrControllerBase
    {
        public MerchantController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<CreateMerchantResponse> Create([FromBody] CreateMerchantCommand request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);

        [HttpGet]
        public async Task<List<GetAllMerchantQueryResponse>> GetAll(CancellationToken cancellationToken) 
            => await _mediator.Send(new GetAllMerchantsQuery(), cancellationToken);
    }
}
