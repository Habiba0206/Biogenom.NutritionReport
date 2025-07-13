using Biogenom.NutritionReport.Domain.Common.Entities;

namespace Biogenom.NutritionReport.Domain.Entities;

public class NutrientConsumption : AuditableEntity
{
    public Guid ReportId { get; set; }

    public string Name { get; set; } = default!;
    public double CurrentValue { get; set; }            
    public string Unit { get; set; } = default!;  
    public double RecommendedMin { get; set; }              
    public double RecommendedMax { get; set; }              
    public bool IsDeficient { get; set; }

    public Report Report { get; set; } = default!;
}
