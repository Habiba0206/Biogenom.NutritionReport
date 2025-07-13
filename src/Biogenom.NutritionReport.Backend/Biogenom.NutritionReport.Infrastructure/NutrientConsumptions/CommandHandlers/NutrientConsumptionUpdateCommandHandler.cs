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

public class NutrientConsumptionUpdateCommandHandler(
    IMapper mapper,
    INutrientConsumptionService service,
    NutrientConsumptionValidator validator) : ICommandHandler<NutrientConsumptionUpdateCommand, NutrientConsumptionCreateUpdateDto>
{
    public async Task<NutrientConsumptionCreateUpdateDto> Handle(NutrientConsumptionUpdateCommand request, CancellationToken cancellationToken)
    {
        var vr = await validator.ValidateAsync(
            request.NutrientConsumptionCreateUpdateDto,
            o => o.IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!vr.IsValid) throw new ValidationException(vr.Errors);

        var entity = mapper.Map<NutrientConsumption>(request.NutrientConsumptionCreateUpdateDto);
        var updated = await service.UpdateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<NutrientConsumptionCreateUpdateDto>(updated);
    }
}