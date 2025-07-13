using Biogenom.NutritionReport.Domain.Common.Queries;

namespace Biogenom.NutritionReport.Persistence.Extensions;

/// <summary>
/// Provides extension methods for applying query specifications to IQueryable and IEnumerable collections.
/// </summary>
public static class LinqExtensions
{
    /// <summary>
    /// Applies pagination to and IQeryable data source.
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the data source.</typeparam>
    /// <param name="sources">The IQueyable source to paginate.</param>
    /// <param name="filterPagination">Pagination options such as page token and page size.</param>
    /// <returns>An IQueryable representing the paginated subset of the oeiginal data source.</returns>
    public static IQueryable<TSource> ApplyPagination<TSource>(
        this IQueryable<TSource> sources,
        FilterPagination? filterPagination)
    {

        return filterPagination == null ? sources : sources
            .Skip((int)((filterPagination.PageToken - 1) * filterPagination.PageSize))
            .Take((int)filterPagination.PageSize);
    }

    /// <summary>
    /// Applies pagination to and IEnumerable data source.
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the data source.</typeparam>
    /// <param name="sources">The IEnumerable source to paginate.</param>
    /// <param name="filterPagination">Pagination options such as page token and page size.</param>
    /// <returns>An IEnumerable representing the paginated subset of the oeiginal data source.</returns>
    public static IEnumerable<TSource> ApplyPagination<TSource>(
    this IEnumerable<TSource> sources,
    FilterPagination? filterPagination)
    {
        return filterPagination == null ? sources : sources
            .Skip((filterPagination.PageToken!.Value - 1) * filterPagination.PageSize!.Value)
            .Take(filterPagination.PageSize!.Value);
    }
}
