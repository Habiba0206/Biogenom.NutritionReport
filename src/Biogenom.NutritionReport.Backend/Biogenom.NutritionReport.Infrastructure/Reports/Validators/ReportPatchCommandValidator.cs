using Biogenom.NutritionReport.Application.Reports.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Reports.Validators;

public class ReportPatchCommandValidator : AbstractValidator<ReportPatchCommand>
{
    public ReportPatchCommandValidator()
    {
        RuleFor(x => x.ReportPatchDto)
            .NotNull().WithMessage("Patch DTO must not be null.");

        RuleFor(x => x.ReportPatchDto.Id)
            .NotEmpty().WithMessage("Id is required for patching.");
    }
}