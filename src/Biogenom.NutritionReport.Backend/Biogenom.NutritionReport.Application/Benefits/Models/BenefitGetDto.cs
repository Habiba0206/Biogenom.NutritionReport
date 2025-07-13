using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Domain.Entities;

namespace Biogenom.NutritionReport.Application.Benefits.Models;

public class BenefitGetDto
{
    public Guid Id  { get; set; }
    public Guid ReportId { get; set; }

    public string Text { get; set; } = default!;

    public ReportCreateUpdateDto Report { get; set; } = default!;
}
