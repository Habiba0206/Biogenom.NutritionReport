using Biogenom.NutritionReport.Domain.Common.Entities;

namespace Biogenom.NutritionReport.Domain.Entities;

public class PersonalizedIntake : AuditableEntity
{
    public Guid ReportId { get; set; }

    public string NutrientName { get; set; } = default!; 
    public double NewValue { get; set; }                 
    public string Unit { get; set; } = default!;     
    public string Source { get; set; } = "Total";      

    public Report Report { get; set; } = default!;
}
