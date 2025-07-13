using AutoMapper;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Commands;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Entities;
using Biogenom.NutritionReport.Domain.Enums;
using Biogenom.NutritionReport.Infrastructure.PersonalizedIntakes.Validators;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.PersonalizedIntakes.CommandHandlers;

public class PersonalizedIntakeUpdateCommandHandler(
    IMapper mapper,
    IPersonalizedIntakeService service,
    PersonalizedIntakeValidator validator) : ICommandHandler<PersonalizedIntakeUpdateCommand, PersonalizedIntakeCreateUpdateDto>
{
    public async Task<PersonalizedIntakeCreateUpdateDto> Handle(PersonalizedIntakeUpdateCommand request, CancellationToken cancellationToken)
    {
        var vr = await validator.ValidateAsync(
            request.PersonalizedIntakeCreateUpdateDto,
            o => o.IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!vr.IsValid) throw new ValidationException(vr.Errors);

        var entity = mapper.Map<PersonalizedIntake>(request.PersonalizedIntakeCreateUpdateDto);
        var updated = await service.UpdateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<PersonalizedIntakeCreateUpdateDto>(updated);
    }
}