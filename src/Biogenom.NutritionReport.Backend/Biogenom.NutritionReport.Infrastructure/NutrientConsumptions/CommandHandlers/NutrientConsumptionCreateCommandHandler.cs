using AutoMapper;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Commands;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Models;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Entities;
using Biogenom.NutritionReport.Domain.Enums;
using Biogenom.NutritionReport.Infrastructure.NutrientConsumptions.Validators;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.NutrientConsumptions.CommandHandlers;

public class NutrientConsumptionCreateCommandHandler(
    IMapper mapper,
    INutrientConsumptionService service,
    NutrientConsumptionValidator validator) : ICommandHandler<NutrientConsumptionCreateCommand, NutrientConsumptionCreateUpdateDto>
{
    public async Task<NutrientConsumptionCreateUpdateDto> Handle(NutrientConsumptionCreateCommand request, CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(
            request.NutrientConsumptionCreateUpdateDto,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        var entity = mapper.Map<NutrientConsumption>(request.NutrientConsumptionCreateUpdateDto);
        var created = await service.CreateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<NutrientConsumptionCreateUpdateDto>(created);
    }
}