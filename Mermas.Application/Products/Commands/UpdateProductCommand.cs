using AutoMapper;
using MediatR;
using Mermas.Application.Common.Exceptions;
using Mermas.Application.Common.Interfaces;
using Mermas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mermas.Application.Products.Commands
{
    public class UpdateProductCommand : IRequest<UpdateProductResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }

    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
    {
        IMermasDbContext _context;
        IMapper _mapper;

        public UpdateProductCommandHandler(IMermasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(m => m.Id == request.Id).Include(m => m.Category).FirstOrDefault();

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }
      
            product.Title = request.Title;
            product.Description = request.Description;
            product.StockQuantity = request.StockQuantity;

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateProductResponse
            {
                ProductId = product.Id
            };
        }
    }

    public class UpdateProductResponse
    {
        public int ProductId { get; set; }
    }
}
