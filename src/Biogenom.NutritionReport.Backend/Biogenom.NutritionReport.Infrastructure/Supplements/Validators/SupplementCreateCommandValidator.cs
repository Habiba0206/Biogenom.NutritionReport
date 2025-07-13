using Biogenom.NutritionReport.Application.Supplements.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Supplements.Validators;

public class SupplementCreateCommandValidator : AbstractValidator<SupplementCreateCommand>
{
    public SupplementCreateCommandValidator()
    {
        RuleFor(x => x.SupplementCreateUpdateDto)
            .NotNull().WithMessage("SupplementDto cannot be null.")
            .SetValidator(new SupplementValidator());
    }
}