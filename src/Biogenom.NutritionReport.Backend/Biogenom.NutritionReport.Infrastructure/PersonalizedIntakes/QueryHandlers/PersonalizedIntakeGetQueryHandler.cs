using AutoMapper;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Queries;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Services;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Infrastructure.Common.Validators;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.NutritionReport.Infrastructure.PersonalizedIntakes.QueryHandlers;

public class PersonalizedIntakeGetQueryHandler(
    IMapper mapper,
    IPersonalizedIntakeService service,
    GetQueryValidator validator)
    : IQueryHandler<PersonalizedIntakeGetQuery, ICollection<PersonalizedIntakeGetDto>>
{
    public async Task<ICollection<PersonalizedIntakeGetDto>> Handle(PersonalizedIntakeGetQuery request, CancellationToken cancellationToken)
    {
        var filter = request.PersonalizedIntakeFilter ?? new PersonalizedIntakeFilter();

        var data = await service.Get(
                filter,
                new QueryOptions { QueryTrackingMode = QueryTrackingMode.AsNoTracking })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<PersonalizedIntakeGetDto>>(data);
    }
}