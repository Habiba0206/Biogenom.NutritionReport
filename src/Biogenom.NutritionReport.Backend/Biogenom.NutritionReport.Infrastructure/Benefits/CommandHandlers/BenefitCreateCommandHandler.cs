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

public class BenefitCreateCommandHandler(
    IMapper mapper,
    IBenefitService service,
    BenefitValidator validator) : ICommandHandler<BenefitCreateCommand, BenefitCreateUpdateDto>
{
    public async Task<BenefitCreateUpdateDto> Handle(BenefitCreateCommand request, CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(
            request.BenefitCreateUpdateDto,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        var entity = mapper.Map<Benefit>(request.BenefitCreateUpdateDto);
        var created = await service.CreateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<BenefitCreateUpdateDto>(created);
    }
}