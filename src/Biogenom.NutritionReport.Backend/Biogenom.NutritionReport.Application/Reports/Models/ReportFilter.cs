using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Application.Reports.Models;

public class ReportFilter : FilterPagination
{
    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(PageToken);
        hashCode.Add(PageSize);
        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj) =>
        obj is ReportFilter filter && filter.GetHashCode() == GetHashCode();
}