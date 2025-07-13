using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.Benefits.Models;

public class BenefitFilter : FilterPagination
{
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(PageToken);
        hashCode.Add(PageSize);
        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj) =>
        obj is BenefitFilter filter && filter.GetHashCode() == GetHashCode();
}