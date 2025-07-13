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

public class PersonalizedIntakeCreateCommandHandler(
    IMapper mapper,
    IPersonalizedIntakeService service,
    PersonalizedIntakeValidator validator) : ICommandHandler<PersonalizedIntakeCreateCommand, PersonalizedIntakeCreateUpdateDto>
{
    public async Task<PersonalizedIntakeCreateUpdateDto> Handle(PersonalizedIntakeCreateCommand request, CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(
            request.PersonalizedIntakeCreateUpdateDto,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        var entity = mapper.Map<PersonalizedIntake>(request.PersonalizedIntakeCreateUpdateDto);
        var created = await service.CreateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<PersonalizedIntakeCreateUpdateDto>(created);
    }
}