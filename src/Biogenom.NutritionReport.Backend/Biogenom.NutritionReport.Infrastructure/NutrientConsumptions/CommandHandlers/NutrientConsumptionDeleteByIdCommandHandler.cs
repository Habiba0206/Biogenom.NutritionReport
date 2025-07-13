using Biogenom.NutritionReport.Application.NutrientConsumptions.Commands;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Infrastructure.NutrientConsumptions.CommandHandlers;

public class NutrientConsumptionDeleteByIdCommandHandler(INutrientConsumptionService service)
    : ICommandHandler<NutrientConsumptionDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(NutrientConsumptionDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await service.DeleteByIdAsync(request.NutrientConsumptionId, cancellationToken: cancellationToken);
        return result is not null;
    }
}