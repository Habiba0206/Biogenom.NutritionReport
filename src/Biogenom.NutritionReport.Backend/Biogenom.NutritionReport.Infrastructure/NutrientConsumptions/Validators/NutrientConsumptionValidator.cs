using Biogenom.NutritionReport.Application.NutrientConsumptions.Models;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.NutrientConsumptions.Validators;

public class NutrientConsumptionValidator : AbstractValidator<NutrientConsumptionCreateUpdateDto>
{
    public NutrientConsumptionValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nutrient name is required.");

        RuleFor(x => x.Unit)
            .NotEmpty().WithMessage("Unit is required.");

        RuleFor(x => x.CurrentValue)
            .GreaterThanOrEqualTo(0).WithMessage("Current value must be non‑negative.");

        RuleFor(x => x.RecommendedMin)
            .GreaterThanOrEqualTo(0).WithMessage("RecommendedMin must be non‑negative.");

        RuleFor(x => x.RecommendedMax)
            .GreaterThanOrEqualTo(x => x.RecommendedMin)
            .WithMessage("RecommendedMax must be ≥ RecommendedMin.");
    }
}