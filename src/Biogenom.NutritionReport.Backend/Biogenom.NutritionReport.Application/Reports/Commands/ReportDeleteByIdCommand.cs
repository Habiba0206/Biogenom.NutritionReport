using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.Reports.Commands;

public record ReportDeleteByIdCommand : ICommand<bool>
{
    public Guid ReportId { get; set; }
}