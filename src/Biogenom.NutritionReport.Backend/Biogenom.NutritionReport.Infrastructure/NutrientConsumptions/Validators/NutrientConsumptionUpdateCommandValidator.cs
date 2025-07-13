using Biogenom.NutritionReport.Application.NutrientConsumptions.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.NutrientConsumptions.Validators;

public class NutrientConsumptionUpdateCommandValidator : AbstractValidator<NutrientConsumptionUpdateCommand>
{
    public NutrientConsumptionUpdateCommandValidator()
    {
        RuleFor(x => x.NutrientConsumptionCreateUpdateDto)
            .NotNull().WithMessage("NutrientConsumption DTO cannot be null.")
            .SetValidator(new NutrientConsumptionValidator());
    }
}