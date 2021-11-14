using FluentValidation;
using Mermas.Application.Merchant.Commands;

namespace Mermas.Application.Merchant.Validators
{
    public class CreateMerchantValidator : AbstractValidator<CreateMerchantCommand>
    {
        public CreateMerchantValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty().WithMessage("Ticari ünvan boş geçilemez.");
        }
    }
}
