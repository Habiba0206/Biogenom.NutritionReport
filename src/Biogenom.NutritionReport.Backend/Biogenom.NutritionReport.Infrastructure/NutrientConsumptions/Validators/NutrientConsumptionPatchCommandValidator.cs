using Biogenom.NutritionReport.Application.NutrientConsumptions.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.NutrientConsumptions.Validators;

public class NutrientConsumptionPatchCommandValidator : AbstractValidator<NutrientConsumptionPatchCommand>
{
    public NutrientConsumptionPatchCommandValidator()
    {
        RuleFor(x => x.NutrientConsumptionPatchDto)
            .NotNull().WithMessage("Patch DTO must not be null.");

        RuleFor(x => x.NutrientConsumptionPatchDto.Id)
            .NotEmpty().WithMessage("Id is required for patching.");
    }
}