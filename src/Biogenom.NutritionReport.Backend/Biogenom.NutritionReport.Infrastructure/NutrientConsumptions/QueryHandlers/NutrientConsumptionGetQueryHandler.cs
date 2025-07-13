using AutoMapper;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Models;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Queries;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Services;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Infrastructure.Common.Validators;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.NutritionReport.Infrastructure.NutrientConsumptions.QueryHandlers;

public class NutrientConsumptionGetQueryHandler(
    IMapper mapper,
    INutrientConsumptionService service,
    GetQueryValidator validator)
    : IQueryHandler<NutrientConsumptionGetQuery, ICollection<NutrientConsumptionGetDto>>
{
    public async Task<ICollection<NutrientConsumptionGetDto>> Handle(NutrientConsumptionGetQuery request, CancellationToken cancellationToken)
    {
        var filter = request.NutrientConsumptionFilter ?? new NutrientConsumptionFilter();
        
        var data = await service.Get(
                filter,
                new QueryOptions { QueryTrackingMode = QueryTrackingMode.AsNoTracking })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<NutrientConsumptionGetDto>>(data);
    }
}