using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.NutrientConsumptions.Models;

public class NutrientConsumptionFilter : FilterPagination
{
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(PageToken);
        hashCode.Add(PageSize);
        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj) =>
        obj is NutrientConsumptionFilter filter && filter.GetHashCode() == GetHashCode();
}