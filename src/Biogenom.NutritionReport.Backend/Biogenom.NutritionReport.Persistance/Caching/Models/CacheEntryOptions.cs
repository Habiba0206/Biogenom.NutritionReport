namespace Biogenom.NutritionReport.Persistence.Caching.Models;

/// <summary>
/// Represents the options for configuring cache entry behavior.
/// </summary>
public readonly struct CacheEntryOptions
{
    /// <summary>
    /// Gets or sets the absolute expiration time relative to the current moment.
    /// </summary>
    public TimeSpan? AbsoluteExpirationRelativeToNow { get; init; }

    /// <summary>
    /// Gets or sets the sliding expiration time for cached items.
    /// </summary>
    public TimeSpan? SlidingExpiration { get; init; }

    public CacheEntryOptions(TimeSpan? absoluteExpirationRelativeToNow, TimeSpan? slidingExpiration)
    {
        AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow;
        SlidingExpiration = slidingExpiration;
    }
}