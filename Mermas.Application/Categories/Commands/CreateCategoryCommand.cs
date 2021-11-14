using MediatR;
using Mermas.Application.Common.Interfaces;
using Mermas.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mermas.Application.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<CreateCategoryResponse>
    {
        public string Title { get; set; }
        public int ProductMinStockQuantity { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
    {
        IMermasDbContext _context;
        public CreateCategoryCommandHandler(IMermasDbContext context)
        {
            _context = context;
        }
        public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            bool isCategoryTitleExist = _context.Categories.Any(m => m.Title == request.Title);

            if (isCategoryTitleExist)
            {
                throw new ArgumentException($"The category named '{request.Title}' already exists.");
            }

            var category = new Category
            {
                Title = request.Title,
                ProductMinStockQuantity = request.ProductMinStockQuantity
            };

            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateCategoryResponse
            {
                CategoryId = category.Id
            };
        }
    }

    public class CreateCategoryResponse
    {
        public int CategoryId { get; set; }
    }
}
