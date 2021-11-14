using MediatR;
using Mermas.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mermas.Application.Products.Commands
{
    public class UpdateProductStockQuantityCommand : IRequest<UpdateProductStockQuantityResponse>
    {
        public int ProductId { get; set; }
        public int MerchantId { get; set; }
        public int StockQuantity { get; set; }
    }

    public class UpdateProductStockQuantityCommandHandler : IRequestHandler<UpdateProductStockQuantityCommand, UpdateProductStockQuantityResponse>
    {
        IMermasDbContext _context;

        public UpdateProductStockQuantityCommandHandler(IMermasDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateProductStockQuantityResponse> Handle(UpdateProductStockQuantityCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(m => m.Id == request.ProductId && m.Merchant.Id == request.MerchantId).Include(m => m.Merchant).FirstOrDefaultAsync(cancellationToken);
            var merchant = product.Merchant;

            product.Merchant.SetProductStockQuantity(product, request.StockQuantity);
            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateProductStockQuantityResponse
            {
                ProductId = product.Id,
                StockQuantity = product.StockQuantity
            };
        }
    }
    public class UpdateProductStockQuantityResponse
    {
        public int ProductId { get; set; }
        public int StockQuantity { get; set; }
    }
}
