using Biogenom.NutritionReport.Application.NutrientConsumptions.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.NutrientConsumptions.Validators;

public class NutrientConsumptionCreateCommandValidator : AbstractValidator<NutrientConsumptionCreateCommand>
{
    public NutrientConsumptionCreateCommandValidator()
    {
        RuleFor(x => x.NutrientConsumptionCreateUpdateDto)
            .NotNull().WithMessage("NutrientConsumptionDto cannot be null.")
            .SetValidator(new NutrientConsumptionValidator());
    }
}