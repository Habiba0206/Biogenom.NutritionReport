using AutoMapper;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Commands;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Infrastructure.PersonalizedIntakes.CommandHandlers;

public class PersonalizedIntakePatchCommandHandler(
    IPersonalizedIntakeService service,
    IMapper mapper)
    : ICommandHandler<PersonalizedIntakePatchCommand, PersonalizedIntakePatchDto>
{
    public async Task<PersonalizedIntakePatchDto> Handle(PersonalizedIntakePatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await service.PatchAsync(request.PersonalizedIntakePatchDto, cancellationToken: cancellationToken);
        return mapper.Map<PersonalizedIntakePatchDto>(entity);
    }
}