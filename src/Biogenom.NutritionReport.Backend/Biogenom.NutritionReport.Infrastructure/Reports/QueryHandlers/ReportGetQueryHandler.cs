using AutoMapper;
using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Application.Reports.Queries;
using Biogenom.NutritionReport.Application.Reports.Services;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Infrastructure.Common.Validators;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.NutritionReport.Infrastructure.Reports.QueryHandlers;

public class ReportGetQueryHandler(
    IMapper mapper,
    IReportService service,
    GetQueryValidator validator)
    : IQueryHandler<ReportGetQuery, ICollection<ReportGetDto>>
{
    public async Task<ICollection<ReportGetDto>> Handle(ReportGetQuery request, CancellationToken cancellationToken)
    {
        var filter = request.ReportFilter ?? new ReportFilter();
        
        var data = await service.Get(
                filter,
                new QueryOptions { QueryTrackingMode = QueryTrackingMode.AsNoTracking })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<ReportGetDto>>(data);
    }
}