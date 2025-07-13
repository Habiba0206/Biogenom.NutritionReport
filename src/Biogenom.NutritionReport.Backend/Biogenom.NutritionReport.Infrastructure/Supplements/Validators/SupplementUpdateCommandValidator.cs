using Biogenom.NutritionReport.Application.Supplements.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Supplements.Validators;

public class SupplementUpdateCommandValidator : AbstractValidator<SupplementUpdateCommand>
{
    public SupplementUpdateCommandValidator()
    {
        RuleFor(x => x.SupplementCreateUpdateDto)
            .NotNull().WithMessage("Supplement DTO cannot be null.")
            .SetValidator(new SupplementValidator());
    }
}