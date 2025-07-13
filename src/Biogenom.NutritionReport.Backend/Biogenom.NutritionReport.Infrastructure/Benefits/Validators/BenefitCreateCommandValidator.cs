using Biogenom.NutritionReport.Application.Benefits.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Benefits.Validators;

public class BenefitCreateCommandValidator : AbstractValidator<BenefitCreateCommand>
{
    public BenefitCreateCommandValidator()
    {
        RuleFor(x => x.BenefitCreateUpdateDto)
            .NotNull().WithMessage("BenefitDto cannot be null.")
            .SetValidator(new BenefitValidator());
    }
}