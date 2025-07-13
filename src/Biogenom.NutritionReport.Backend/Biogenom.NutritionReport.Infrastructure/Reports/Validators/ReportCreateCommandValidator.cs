using Biogenom.NutritionReport.Application.Reports.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Reports.Validators;

public class ReportCreateCommandValidator : AbstractValidator<ReportCreateCommand>
{
    public ReportCreateCommandValidator()
    {
        RuleFor(x => x.ReportCreateUpdateDto)
            .NotNull().WithMessage("ReportDto cannot be null.")
            .SetValidator(new ReportValidator());
    }
}