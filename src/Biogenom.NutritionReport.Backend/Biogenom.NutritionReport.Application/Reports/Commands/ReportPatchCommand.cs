using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.Reports.Commands;

public record ReportPatchCommand : ICommand<ReportPatchDto>
{
    public ReportPatchDto ReportPatchDto { get; set; } = null!;
}