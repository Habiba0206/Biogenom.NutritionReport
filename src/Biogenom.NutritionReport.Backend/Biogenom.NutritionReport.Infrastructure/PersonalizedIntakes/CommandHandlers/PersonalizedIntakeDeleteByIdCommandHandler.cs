using Biogenom.NutritionReport.Application.PersonalizedIntakes.Commands;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Infrastructure.PersonalizedIntakes.CommandHandlers;

public class PersonalizedIntakeDeleteByIdCommandHandler(IPersonalizedIntakeService service)
    : ICommandHandler<PersonalizedIntakeDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(PersonalizedIntakeDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await service.DeleteByIdAsync(request.PersonalizedIntakeId, cancellationToken: cancellationToken);
        return result is not null;
    }
}