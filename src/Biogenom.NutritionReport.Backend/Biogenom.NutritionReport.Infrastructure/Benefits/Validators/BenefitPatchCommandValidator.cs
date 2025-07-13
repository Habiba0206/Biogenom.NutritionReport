using Biogenom.NutritionReport.Application.Benefits.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Benefits.Validators;

public class BenefitPatchCommandValidator : AbstractValidator<BenefitPatchCommand>
{
    public BenefitPatchCommandValidator()
    {
        RuleFor(x => x.BenefitPatchDto)
            .NotNull().WithMessage("Patch DTO must not be null.");

        RuleFor(x => x.BenefitPatchDto.Id)
            .NotEmpty().WithMessage("Id is required for patching.");
    }
}