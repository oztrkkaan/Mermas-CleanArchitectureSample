using FluentValidation;
using Mermas.Application.Products.Commands;

namespace Mermas.Application.Products.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductInfoCommand>
    {
        private const int TITLE_MAX_LENGTH = 200;

        public UpdateProductValidator()
        {
            RuleFor(m => m.Id)
                .GreaterThan(0).WithMessage("Güncellenmek istenen ürün 'Id' bilgisi içermelidir.");

            RuleFor(m => m.Title)
             .NotNull().WithMessage("Ürün adı alanı boş geçilemez.")
             .NotEmpty().WithMessage("Ürün adı alanı boş geçilemez.")
             .MaximumLength(TITLE_MAX_LENGTH).WithMessage($"Ürün adı alanı {TITLE_MAX_LENGTH} karakterden daha kısa olmalı.");
        }

    }
}
