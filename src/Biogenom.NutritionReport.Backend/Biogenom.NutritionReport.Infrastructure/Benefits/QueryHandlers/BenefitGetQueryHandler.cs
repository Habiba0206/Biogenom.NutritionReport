using AutoMapper;
using Biogenom.NutritionReport.Application.Benefits.Models;
using Biogenom.NutritionReport.Application.Benefits.Queries;
using Biogenom.NutritionReport.Application.Benefits.Services;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Infrastructure.Common.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.NutritionReport.Infrastructure.Benefits.QueryHandlers;

public class BenefitGetQueryHandler(
    IMapper mapper,
    IBenefitService service,
    GetQueryValidator validator)
    : IQueryHandler<BenefitGetQuery, ICollection<BenefitGetDto>>
{
    public async Task<ICollection<BenefitGetDto>> Handle(BenefitGetQuery request, CancellationToken cancellationToken)
    {
        var filter = request.BenefitFilter ?? new BenefitFilter();
        
        var data = await service.Get(
                filter,
                new QueryOptions { QueryTrackingMode = QueryTrackingMode.AsNoTracking })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<BenefitGetDto>>(data);
    }
}