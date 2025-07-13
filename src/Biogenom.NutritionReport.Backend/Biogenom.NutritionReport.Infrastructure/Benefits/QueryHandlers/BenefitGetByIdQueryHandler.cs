using AutoMapper;
using Biogenom.NutritionReport.Application.Benefits.Models;
using Biogenom.NutritionReport.Application.Benefits.Queries;
using Biogenom.NutritionReport.Application.Benefits.Services;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Infrastructure.Benefits.QueryHandlers;

public class BenefitGetByIdQueryHandler(
    IMapper mapper,
    IBenefitService service)
    : IQueryHandler<BenefitGetByIdQuery, BenefitGetDto?>
{
    public async Task<BenefitGetDto?> Handle(BenefitGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await service.GetByIdAsync(request.BenefitId, cancellationToken: cancellationToken);
        return mapper.Map<BenefitGetDto?>(entity);
    }
}