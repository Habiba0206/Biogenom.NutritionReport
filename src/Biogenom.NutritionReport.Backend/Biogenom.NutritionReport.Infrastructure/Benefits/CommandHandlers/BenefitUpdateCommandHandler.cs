using AutoMapper;
using Biogenom.NutritionReport.Application.Benefits.Commands;
using Biogenom.NutritionReport.Application.Benefits.Models;
using Biogenom.NutritionReport.Application.Benefits.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Entities;
using Biogenom.NutritionReport.Domain.Enums;
using Biogenom.NutritionReport.Infrastructure.Benefits.Validators;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Benefits.CommandHandlers;

public class BenefitUpdateCommandHandler(
    IMapper mapper,
    IBenefitService service,
    BenefitValidator validator) : ICommandHandler<BenefitUpdateCommand, BenefitCreateUpdateDto>
{
    public async Task<BenefitCreateUpdateDto> Handle(BenefitUpdateCommand request, CancellationToken cancellationToken)
    {
        var vr = await validator.ValidateAsync(
            request.BenefitCreateUpdateDto,
            o => o.IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!vr.IsValid) throw new ValidationException(vr.Errors);

        var entity = mapper.Map<Benefit>(request.BenefitCreateUpdateDto);
        var updated = await service.UpdateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<BenefitCreateUpdateDto>(updated);
    }
}