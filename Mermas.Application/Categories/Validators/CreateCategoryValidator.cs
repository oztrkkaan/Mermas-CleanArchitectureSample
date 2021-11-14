using FluentValidation;
using Mermas.Application.Categories.Commands;

namespace Mermas.Application.Categories.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(m => m.ProductMinStockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage($"Minimum ürün stok miktarı 0 veya daha büyük bir sayı olmalı.");
        }
    }
}
