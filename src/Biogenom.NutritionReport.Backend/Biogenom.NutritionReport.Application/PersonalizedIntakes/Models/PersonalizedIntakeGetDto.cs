using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Domain.Entities;

namespace Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;

public class PersonalizedIntakeGetDto
{
    public Guid Id  { get; set; }
    public Guid ReportId { get; set; }

    public string NutrientName { get; set; } = default!;
    public double NewValue { get; set; }
    public string Unit { get; set; } = default!;
    public string Source { get; set; } = "Total";

    public ReportCreateUpdateDto Report { get; set; } = default!;
}
