using Biogenom.NutritionReport.Application.Supplements.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Supplements.Validators;

public class SupplementPatchCommandValidator : AbstractValidator<SupplementPatchCommand>
{
    public SupplementPatchCommandValidator()
    {
        RuleFor(x => x.SupplementPatchDto)
            .NotNull().WithMessage("Patch DTO must not be null.");

        RuleFor(x => x.SupplementPatchDto.Id)
            .NotEmpty().WithMessage("Id is required for patching.");
    }
}