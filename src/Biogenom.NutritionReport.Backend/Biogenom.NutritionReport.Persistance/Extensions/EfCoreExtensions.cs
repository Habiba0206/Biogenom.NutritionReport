using Biogenom.NutritionReport.Domain.Common.Entities;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.NutritionReport.Persistence.Extensions;

/// <summary>
/// Contains Ef Core internal logic extensions.
/// </summary>
public static class EfCoreExtensions
{
    /// <summary>
    /// Applies pagination to given query source.
    /// </summary>
    /// <typeparam name="TSource">Query source type.</typeparam>
    /// <param name="source">Queryable sourse.</param>
    /// <param name="trackingMode">Tracking mode tp apply.</param>
    /// <returns>Query sourse with pagination applied.</returns>
    public static IQueryable<TSource> ApplyTrackingMode<TSource>(
        this IQueryable<TSource> source,
        QueryTrackingMode trackingMode)
        where TSource : class
    {
        return trackingMode switch
        {
            QueryTrackingMode.AsTracking => source,
            QueryTrackingMode.AsNoTracking => source.AsNoTracking(),
            QueryTrackingMode.AsNoTrackingWithIdentityResolution => source.AsNoTrackingWithIdentityResolution(),
            _ => source
        };
    }

    /// <summary>
    /// Queries th source and return filtered entities.
    /// </summary>
    /// <typeparam name="TSource">Query source type.</typeparam>
    /// <param name="filteredSource">Filtered query source to get entities Id from.</param>
    /// <param name="source">Original quoery source.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>New query with enities Id predicate.</returns>
    public static async ValueTask<IQueryable<TSource>> GetFilteredEntitiesQuery<TSource>(
        this IQueryable<TSource> filteredSource,
        IQueryable<TSource> source,
        CancellationToken cancellationToken = default)
        where TSource : class, IAuditableEntity
    {
        var entitiesId = await filteredSource
            .Select(entity => entity.Id)
            .ToListAsync(cancellationToken: cancellationToken);

        return source.Where(entity => entitiesId.Contains(entity.Id));
    }
}
