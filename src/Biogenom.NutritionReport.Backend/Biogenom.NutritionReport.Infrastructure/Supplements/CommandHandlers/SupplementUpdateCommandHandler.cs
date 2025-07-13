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

public class SupplementUpdateCommandHandler(
    IMapper mapper,
    ISupplementService service,
    SupplementValidator validator) : ICommandHandler<SupplementUpdateCommand, SupplementCreateUpdateDto>
{
    public async Task<SupplementCreateUpdateDto> Handle(SupplementUpdateCommand request, CancellationToken cancellationToken)
    {
        var vr = await validator.ValidateAsync(
            request.SupplementCreateUpdateDto,
            o => o.IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!vr.IsValid) throw new ValidationException(vr.Errors);

        var entity = mapper.Map<Supplement>(request.SupplementCreateUpdateDto);
        var updated = await service.UpdateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<SupplementCreateUpdateDto>(updated);
    }
}