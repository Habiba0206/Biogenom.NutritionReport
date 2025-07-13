using Biogenom.NutritionReport.Application.Reports.Models;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Reports.Validators;

public class ReportValidator : AbstractValidator<ReportCreateUpdateDto>
{
    public ReportValidator()
    {
    }
}