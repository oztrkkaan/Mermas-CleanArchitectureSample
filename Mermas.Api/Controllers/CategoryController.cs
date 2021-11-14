using MediatR;
using Mermas.Api.Common;
using Mermas.Application.Categories.Commands;
using Mermas.Application.Categories.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mermas.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : MediatrControllerBase
    {
        public CategoryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<CreateCategoryResponse> Create([FromBody] CreateCategoryCommand request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);

        [HttpGet]
        public async Task<List<GetAllCategoriesResponse>> GetAll(CancellationToken cancellationToken)
            => await _mediator.Send(new GetAllCategoriesQuery(), cancellationToken);

    }
}
