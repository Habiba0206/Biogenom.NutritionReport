using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;

public class PersonalizedIntakeFilter : FilterPagination
{
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(PageToken);
        hashCode.Add(PageSize);
        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj) =>
        obj is PersonalizedIntakeFilter filter && filter.GetHashCode() == GetHashCode();
}