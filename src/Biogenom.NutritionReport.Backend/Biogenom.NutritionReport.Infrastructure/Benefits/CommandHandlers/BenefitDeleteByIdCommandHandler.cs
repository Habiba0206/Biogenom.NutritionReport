using Biogenom.NutritionReport.Application.Benefits.Commands;
using Biogenom.NutritionReport.Application.Benefits.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Infrastructure.Benefits.CommandHandlers;

public class BenefitDeleteByIdCommandHandler(IBenefitService service)
    : ICommandHandler<BenefitDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(BenefitDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await service.DeleteByIdAsync(request.BenefitId, cancellationToken: cancellationToken);
        return result is not null;
    }
}