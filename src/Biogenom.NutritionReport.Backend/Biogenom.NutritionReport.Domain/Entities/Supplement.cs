using Biogenom.NutritionReport.Domain.Common.Entities;

namespace Biogenom.NutritionReport.Domain.Entities;

public class Supplement : AuditableEntity
{
    public Guid ReportId { get; set; }

    public string Name { get; set; } = default!;      
    public string ImageUrl { get; set; } = default!;      
    public string Description { get; set; } = default!;      

    public Report Report { get; set; } = default!;
}
