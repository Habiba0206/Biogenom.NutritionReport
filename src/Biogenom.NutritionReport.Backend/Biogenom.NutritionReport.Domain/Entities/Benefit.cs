using Biogenom.NutritionReport.Domain.Common.Entities;

namespace Biogenom.NutritionReport.Domain.Entities;

public class Benefit : AuditableEntity
{
    public Guid ReportId { get; set; }

    public string Text { get; set; } = default!;

    public Report Report { get; set; } = default!;
}
