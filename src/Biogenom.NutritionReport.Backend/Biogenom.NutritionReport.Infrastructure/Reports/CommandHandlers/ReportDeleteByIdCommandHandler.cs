using Biogenom.NutritionReport.Application.Reports.Commands;
using Biogenom.NutritionReport.Application.Reports.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Infrastructure.Reports.CommandHandlers;

public class ReportDeleteByIdCommandHandler(IReportService service)
    : ICommandHandler<ReportDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(ReportDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await service.DeleteByIdAsync(request.ReportId, cancellationToken: cancellationToken);
        return result is not null;
    }
}