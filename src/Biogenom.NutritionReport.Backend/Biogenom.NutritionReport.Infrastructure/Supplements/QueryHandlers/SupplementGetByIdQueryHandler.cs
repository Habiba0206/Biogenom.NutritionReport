using AutoMapper;
using Biogenom.NutritionReport.Application.Supplements.Models;
using Biogenom.NutritionReport.Application.Supplements.Queries;
using Biogenom.NutritionReport.Application.Supplements.Services;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Infrastructure.Supplements.QueryHandlers;

public class SupplementGetByIdQueryHandler(
    IMapper mapper,
    ISupplementService service)
    : IQueryHandler<SupplementGetByIdQuery, SupplementGetDto?>
{
    public async Task<SupplementGetDto?> Handle(SupplementGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await service.GetByIdAsync(request.SupplementId, cancellationToken: cancellationToken);
        return mapper.Map<SupplementGetDto?>(entity);
    }
}