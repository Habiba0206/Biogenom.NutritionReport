using AutoMapper;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Commands;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Models;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Infrastructure.NutrientConsumptions.CommandHandlers;

public class NutrientConsumptionPatchCommandHandler(
    INutrientConsumptionService service,
    IMapper mapper)
    : ICommandHandler<NutrientConsumptionPatchCommand, NutrientConsumptionPatchDto>
{
    public async Task<NutrientConsumptionPatchDto> Handle(NutrientConsumptionPatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await service.PatchAsync(request.NutrientConsumptionPatchDto, cancellationToken: cancellationToken);
        return mapper.Map<NutrientConsumptionPatchDto>(entity);
    }
}