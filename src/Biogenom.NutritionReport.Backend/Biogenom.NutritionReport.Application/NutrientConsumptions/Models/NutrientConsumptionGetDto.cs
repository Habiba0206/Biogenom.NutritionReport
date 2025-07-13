using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Domain.Entities;

namespace Biogenom.NutritionReport.Application.NutrientConsumptions.Models;

public class NutrientConsumptionGetDto
{
    public Guid Id { get; set; }
    public Guid ReportId { get; set; }

    public string Name { get; set; } = default!;
    public double CurrentValue { get; set; }
    public string Unit { get; set; } = default!;
    public double RecommendedMin { get; set; }
    public double RecommendedMax { get; set; }
    public bool IsDeficient { get; set; }

    public ReportCreateUpdateDto Report { get; set; } = default!;
}
