using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.Supplements.Models;

public class SupplementFilter : FilterPagination
{
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(PageToken);
        hashCode.Add(PageSize);
        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj) =>
        obj is SupplementFilter filter && filter.GetHashCode() == GetHashCode();
}