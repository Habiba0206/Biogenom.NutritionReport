using AutoMapper;
using Biogenom.NutritionReport.Application.Supplements.Models;
using Biogenom.NutritionReport.Application.Supplements.Queries;
using Biogenom.NutritionReport.Application.Supplements.Services;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Infrastructure.Common.Validators;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.NutritionReport.Infrastructure.Supplements.QueryHandlers;

public class SupplementGetQueryHandler(
    IMapper mapper,
    ISupplementService service,
    GetQueryValidator validator)
    : IQueryHandler<SupplementGetQuery, ICollection<SupplementGetDto>>
{
    public async Task<ICollection<SupplementGetDto>> Handle(SupplementGetQuery request, CancellationToken cancellationToken)
    {
        var filter = request.SupplementFilter ?? new SupplementFilter();
        
        var data = await service.Get(
                filter,
                new QueryOptions { QueryTrackingMode = QueryTrackingMode.AsNoTracking })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<SupplementGetDto>>(data);
    }
}