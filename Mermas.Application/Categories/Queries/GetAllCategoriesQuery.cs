using AutoMapper;
using MediatR;
using Mermas.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mermas.Application.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<GetAllCategoriesResponse>>
    {
    }

    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<GetAllCategoriesResponse>>
    {
        IMermasDbContext _context;
        IMapper _mapper;
        public GetAllCategoriesQueryHandler(IMermasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllCategoriesResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.ToListAsync(cancellationToken);

            return _mapper.Map<List<GetAllCategoriesResponse>>(categories);
        }
    }

    public class GetAllCategoriesResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MinProductStockQuantity { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
