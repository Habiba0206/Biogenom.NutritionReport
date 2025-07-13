using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.Reports.Commands;

public record ReportCreateCommand : ICommand<ReportCreateUpdateDto>
{
    public ReportCreateUpdateDto ReportCreateUpdateDto { get; set; }
}