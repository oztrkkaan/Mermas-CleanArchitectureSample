using FluentValidation;
using Mermas.Application.Products.Commands;

namespace Mermas.Application.Products.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        private const int TITLE_MAX_LENGTH = 200;
        public CreateProductValidator()
        {
            RuleFor(m => m.Title)
                .NotNull().WithMessage("Ürün adı alanı boş geçilemez.")
                .NotEmpty().WithMessage("Ürün adı alanı boş geçilemez.")
                .MaximumLength(TITLE_MAX_LENGTH).WithMessage($"Ürün adı alanı {TITLE_MAX_LENGTH} karakterden daha kısa olmalı.");

            RuleFor(m => m.CategoryId)
                .GreaterThan(0).WithMessage("Ürün bir kategoriye ait olmalıdır.");

            RuleFor(m => m.MerchantId)
             .GreaterThan(0).WithMessage("Ürün bir mağazaya ait olmalıdır.");
        }
    }
}
