using AutoMapper;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Models;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Queries;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Services;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Infrastructure.NutrientConsumptions.QueryHandlers;

public class NutrientConsumptionGetByIdQueryHandler(
    IMapper mapper,
    INutrientConsumptionService service)
    : IQueryHandler<NutrientConsumptionGetByIdQuery, NutrientConsumptionGetDto?>
{
    public async Task<NutrientConsumptionGetDto?> Handle(NutrientConsumptionGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await service.GetByIdAsync(request.NutrientConsumptionId, cancellationToken: cancellationToken);
        return mapper.Map<NutrientConsumptionGetDto?>(entity);
    }
}