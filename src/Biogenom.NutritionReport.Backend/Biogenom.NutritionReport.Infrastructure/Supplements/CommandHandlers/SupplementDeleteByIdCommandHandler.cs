using Biogenom.NutritionReport.Application.Supplements.Commands;
using Biogenom.NutritionReport.Application.Supplements.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Infrastructure.Supplements.CommandHandlers;

public class SupplementDeleteByIdCommandHandler(ISupplementService service)
    : ICommandHandler<SupplementDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(SupplementDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await service.DeleteByIdAsync(request.SupplementId, cancellationToken: cancellationToken);
        return result is not null;
    }
}