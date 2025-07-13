using AutoMapper;
using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Application.Reports.Queries;
using Biogenom.NutritionReport.Application.Reports.Services;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Infrastructure.Reports.QueryHandlers;

public class ReportGetByIdQueryHandler(
    IMapper mapper,
    IReportService service)
    : IQueryHandler<ReportGetByIdQuery, ReportGetDto?>
{
    public async Task<ReportGetDto?> Handle(ReportGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await service.GetByIdAsync(request.ReportId, cancellationToken: cancellationToken);
        return mapper.Map<ReportGetDto?>(entity);
    }
}