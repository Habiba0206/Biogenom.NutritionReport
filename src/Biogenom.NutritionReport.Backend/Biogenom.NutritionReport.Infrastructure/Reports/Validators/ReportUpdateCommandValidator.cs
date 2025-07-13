using Biogenom.NutritionReport.Application.Reports.Commands;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Reports.Validators;

public class ReportUpdateCommandValidator : AbstractValidator<ReportUpdateCommand>
{
    public ReportUpdateCommandValidator()
    {
        RuleFor(x => x.ReportCreateUpdateDto)
            .NotNull().WithMessage("Report DTO cannot be null.")
            .SetValidator(new ReportValidator());
    }
}