using MediatR;
using Mermas.Application.Common.Exceptions;
using Mermas.Application.Common.Interfaces;
using Mermas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mermas.Application.Products.Commands
{
    public class UpdateProductCategoryCommand : IRequest<UpdateProductCategoryResponse>
    {
        public int ProductId { get; set; }
        public int MerchantId { get; set; }
        public int CategoryId { get; set; }
    }
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, UpdateProductCategoryResponse>
    {
        IMermasDbContext _context;

        public UpdateProductCategoryCommandHandler(IMermasDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateProductCategoryResponse> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(m => m.Id == request.ProductId && m.Merchant.Id == request.MerchantId).Include(m => m.Merchant).FirstOrDefault();
            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            var merchant = product.Merchant;
            if (merchant == null)
            {
                throw new NotFoundException(nameof(Merchant), request.MerchantId);
            }

            var category = _context.Categories.Find(request.CategoryId);
            if (category == null)
            {
                throw new NotFoundException(nameof(Category), request.CategoryId);
            }
            
            product.SetCategory(category);
            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateProductCategoryResponse
            {
                CategoryId = category.Id,
                ProductId = product.Id
            };
        }
    }

    public class UpdateProductCategoryResponse
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
