using AutoMapper;
using Biogenom.NutritionReport.Application.Supplements.Commands;
using Biogenom.NutritionReport.Application.Supplements.Models;
using Biogenom.NutritionReport.Application.Supplements.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Entities;
using Biogenom.NutritionReport.Domain.Enums;
using Biogenom.NutritionReport.Infrastructure.Supplements.Validators;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Supplements.CommandHandlers;

public class SupplementCreateCommandHandler(
    IMapper mapper,
    ISupplementService service,
    SupplementValidator validator) : ICommandHandler<SupplementCreateCommand, SupplementCreateUpdateDto>
{
    public async Task<SupplementCreateUpdateDto> Handle(SupplementCreateCommand request, CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(
            request.SupplementCreateUpdateDto,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        var entity = mapper.Map<Supplement>(request.SupplementCreateUpdateDto);
        var created = await service.CreateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<SupplementCreateUpdateDto>(created);
    }
}