using AutoMapper;
using MediatR;
using Mermas.Application.Common.Exceptions;
using Mermas.Application.Common.Interfaces;
using Mermas.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mermas.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<CreateProductResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public int MerchantId { get; set; }
    }


    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
    {
        private readonly IMermasDbContext _context;

        public CreateProductCommandHandler(IMermasDbContext context)
        {
            _context = context;
        }

        public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productCategory = _context.Categories.FirstOrDefault(m => m.Id == request.CategoryId);
            var productMerchant = _context.Merchants.FirstOrDefault(m => m.Id == request.MerchantId);

            if (productCategory == null)
            {
                throw new NotFoundException(nameof(Category), request.CategoryId);
            }
            if (productMerchant == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Merchant), request.MerchantId);
            }

            var product = productMerchant.CreateProduct(
                      request.Title,
                      request.Description,
                      request.StockQuantity,
                      productCategory
                      );


            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateProductResponse
            {
                ProductId = product.Id
            };
        }
    }

    public class CreateProductResponse
    {
        public int ProductId { get; set; }
    }


}
