using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.Reports.Commands;

public record ReportUpdateCommand : ICommand<ReportCreateUpdateDto>
{
    public ReportCreateUpdateDto ReportCreateUpdateDto { get; set; }
}