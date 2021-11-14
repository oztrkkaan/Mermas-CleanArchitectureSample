using MediatR;
using Mermas.Application.Common.Exceptions;
using Mermas.Application.Common.Interfaces;
using Mermas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mermas.Application.Products.Commands
{
    public class DeleteProductCommand : IRequest<DeleteProductResponse>
    {
        public int ProductId { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
    {
        IMermasDbContext _context;

        public DeleteProductCommandHandler(IMermasDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Products.Find(request.ProductId);
            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return new DeleteProductResponse
            {
                Id = product.Id
            };
        }
    }
    public class DeleteProductResponse
    {
        public int Id { get; set; }
    }
}
