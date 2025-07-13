using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.Reports.Queries;

public record ReportGetByIdQuery : IQuery<ReportGetDto?>
{
    public Guid ReportId { get; set; }
}