using Biogenom.NutritionReport.Application.Benefits.Models;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Benefits.Validators;

public class BenefitValidator : AbstractValidator<BenefitCreateUpdateDto>
{
    public BenefitValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Benefit text is required.");
    }
}