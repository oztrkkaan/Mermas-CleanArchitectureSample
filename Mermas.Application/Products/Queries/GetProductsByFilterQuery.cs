using AutoMapper;
using MediatR;
using Mermas.Application.Common.Interfaces;
using Mermas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mermas.Application.Products.Queries
{
    public class GetProductsByFilterQuery : IRequest<List<GetProductsByFilterResponse>>
    {
        public string SearchKey { get; set; }
        public int? MinStockQuantityValue { get; set; }
        public int? MaxStockQuantityValue { get; set; }
    }

    public class GetProductsByFilterQueryHandler : IRequestHandler<GetProductsByFilterQuery, List<GetProductsByFilterResponse>>
    {
        IMermasDbContext _context;
        IMapper _mapper;
        public GetProductsByFilterQueryHandler(IMermasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetProductsByFilterResponse>> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
        {
           IQueryable<Product>  products = _context.Products.Include(m => m.Category);

            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                products = products.Where(m => m.Title.Contains(request.SearchKey) || m.Description.Contains(request.SearchKey) || m.Category.Title.Contains(request.SearchKey));
            }
            if (request.MinStockQuantityValue != null)
            {
                products = products.Where(m => m.StockQuantity >= (int)request.MinStockQuantityValue);
            }
            if (request.MaxStockQuantityValue != null)
            {
                products = products.Where(m => m.StockQuantity <= (int)request.MaxStockQuantityValue);
            }

            return _mapper.Map<List<GetProductsByFilterResponse>>(await products.ToListAsync(cancellationToken));
        }
    }

    public class GetProductsByFilterResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public GetProductCategoryByFilter Category { get; set; }
    }
    public class GetProductCategoryByFilter
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }



}
