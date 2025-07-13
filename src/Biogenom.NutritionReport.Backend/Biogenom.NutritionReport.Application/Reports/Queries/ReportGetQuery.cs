using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.Reports.Queries;

public record ReportGetQuery : IQuery<ICollection<ReportGetDto>>
{
    public ReportFilter ReportFilter { get; set; }
}