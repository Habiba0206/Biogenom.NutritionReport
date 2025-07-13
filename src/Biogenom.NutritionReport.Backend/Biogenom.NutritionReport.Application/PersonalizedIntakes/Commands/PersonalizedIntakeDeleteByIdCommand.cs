using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Application.PersonalizedIntakes.Commands;

public record PersonalizedIntakeDeleteByIdCommand : ICommand<bool>
{
    public Guid PersonalizedIntakeId { get; set; }
}
