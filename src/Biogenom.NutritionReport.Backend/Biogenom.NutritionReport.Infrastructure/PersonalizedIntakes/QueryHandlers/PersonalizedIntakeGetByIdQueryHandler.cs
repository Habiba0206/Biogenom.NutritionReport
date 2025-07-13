using AutoMapper;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Queries;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Services;
using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Infrastructure.PersonalizedIntakes.QueryHandlers;

public class PersonalizedIntakeGetByIdQueryHandler(
    IMapper mapper,
    IPersonalizedIntakeService service)
    : IQueryHandler<PersonalizedIntakeGetByIdQuery, PersonalizedIntakeGetDto?>
{
    public async Task<PersonalizedIntakeGetDto?> Handle(PersonalizedIntakeGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await service.GetByIdAsync(request.PersonalizedIntakeId, cancellationToken: cancellationToken);
        return mapper.Map<PersonalizedIntakeGetDto?>(entity);
    }
}