using Biogenom.NutritionReport.Application.Benefits.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Benefits.Validators;

public class BenefitUpdateCommandValidator : AbstractValidator<BenefitUpdateCommand>
{
    public BenefitUpdateCommandValidator()
    {
        RuleFor(x => x.BenefitCreateUpdateDto)
            .NotNull().WithMessage("Benefit DTO cannot be null.")
            .SetValidator(new BenefitValidator());
    }
}