namespace Biogenom.NutritionReport.Application.NutrientConsumptions.Models;

public class NutrientConsumptionCreateUpdateDto
{
    public Guid? Id { get; set; }
    public Guid ReportId { get; set; }

    public string Name { get; set; } = default!;
    public double CurrentValue { get; set; }
    public string Unit { get; set; } = default!;
    public double RecommendedMin { get; set; }
    public double RecommendedMax { get; set; }
    public bool IsDeficient { get; set; }
}
